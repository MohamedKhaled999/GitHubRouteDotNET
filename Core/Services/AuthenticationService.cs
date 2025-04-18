using Domain.Entities.Identity;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions;
using Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class AuthenticationService(UserManager<User> _userManager ,Manager) : IAuthenticationService
    {
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
                Token : ""
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
                "Token"


                );

        }
    }
}
