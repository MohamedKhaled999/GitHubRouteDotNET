using AutoMapper;
using Domain.Entities.Identity;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstractions;
using Shared.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class AuthenticationService(UserManager<User> _userManager,IOptions<JwtOptions> options ,IMapper mapper) : IAuthenticationService
    {
        public async Task<bool> CheckEmailExist(string email)
        {
          var user=  await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<AddressDto> GetUserAddress(string email)
        {
            var user =      await _userManager.Users
                            .Include(U=>U.Address)
                            .FirstOrDefaultAsync(u=>u.Email==email)
                            ??throw new UserNotFoundException(email)
                            ;

            var address= user?.Address;

            return mapper.Map<AddressDto>(address); 
        }

        public async Task<UserResultDto> GetUserByEmail(string email)
        {
           var user = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);
            return new UserResultDto(user.DisplayName,user.Email, await CreateTokenAsync(user))
           ;
        }

        public async Task<AddressDto> UpdateUserAddress(AddressDto address, string email)
        {
            var user = await _userManager.Users
                            .Include(U => U.Address)
                            .FirstOrDefaultAsync(u => u.Email == email)
                            ?? throw new UserNotFoundException(email)
                            ;

            if (user.Address != null)
            {
                user.Address.FristName = address.FirstName;
                user.Address.LastName = address.LastName;
                user.Address.City = address.City;
                user.Address.Street = address.Street;
                user.Address.Country = address.Country;
            }
            else
            {
                user.Address = mapper.Map<Address>(address);
            }


          
                var res = await _userManager.UpdateAsync(user);

            if (res.Errors.Any())
                throw new Exception("UpdateUserAddress error");


            return mapper.Map<AddressDto>(user.Address);



        }
        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) throw new UnAuthorizedException("Invalid Email !!"); // Email not found !!


            var Result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (Result == false) throw new UnAuthorizedException("Invalid Password !!");//Wrong Password !!

            //Create Token (JWT)

            return new UserResultDto
            (
                Email : user.Email,
                DisplayName : user.DisplayName,
                Token : await CreateTokenAsync(user)
            );
        }

        public async Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User { 
                Email = registerDto.Email 
                ,PhoneNumber = registerDto.PhoneNumber,
                DisplayName =registerDto.DisplayName,
                UserName = registerDto.UserName,
            };
                
                
             var result =   await _userManager.CreateAsync(user,registerDto.Password);

            if (!result.Succeeded)
            {

                var errors= result.Errors.Select(e=>e.Description).ToList();
                throw new RegisterValidationException(errors);

            }

            return new UserResultDto(
                user.DisplayName,
                user.Email,
                Token: await CreateTokenAsync(user)

                );

        }

        

        private async Task<string> CreateTokenAsync(User user)
        {
            var jwtOptions = options.Value;
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name,user.UserName),
                new(ClaimTypes.Email,user.Email),
            };

            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var role in Roles)
            {
                authClaims.Add(new(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecertKey));
            
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken

                (
                audience:jwtOptions.Audience,
                issuer: jwtOptions.Issure,
                expires: DateTime.UtcNow.AddDays(jwtOptions.DurationInDays),
                claims:authClaims,
                signingCredentials: signingCredentials
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}
