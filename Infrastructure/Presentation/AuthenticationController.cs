using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Services.Abstractions;
using Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class AuthenticationController(IServiceManager _serviceManager) : ApiController
    {

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UserResultDto>> Login(LoginDto loginDto)
        {
            if (loginDto is not null)
            {
                var Result = await _serviceManager.AuthenticationService.LoginAsync(loginDto);
                return Ok(Result);
            }


            return BadRequest();
            
        }


        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<UserResultDto>> Register(RegisterDto registerDto)
        {
            if (registerDto is not null)
            {
                var Result = await _serviceManager.AuthenticationService.RegisterAsync(registerDto);
                return Ok(Result);
            }


            return BadRequest();

        }


        [HttpGet("EmailExist")]

        public async Task<ActionResult<UserResultDto>> CheckEmailExist(string email)
        {

            return Ok(await _serviceManager.AuthenticationService.CheckEmailExist(email));

            //return BadRequest();

        }


        [Authorize]
        [HttpGet]

        public async Task<ActionResult<UserResultDto>> GetCurrentUser()
        {
          var  email = User.FindFirstValue(ClaimTypes.Email);


            var user =    await   _serviceManager.AuthenticationService.GetUserByEmail(email);

            return Ok(user);

            //return BadRequest();

        }


        [Authorize]
        [HttpGet("Address")]

        public async Task<ActionResult<AddressDto>> GetAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);


            var addressDto = await _serviceManager.AuthenticationService.GetUserAddress(email);

            return Ok(addressDto);

            //return BadRequest();

        }


        [Authorize]
        [HttpPut("Address")]

        public async Task<ActionResult<AddressDto>> UpdateAddress(AddressDto address)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);


            var addressDto = await _serviceManager.AuthenticationService.UpdateUserAddress(address,email);

            return Ok(addressDto);

            //return BadRequest();

        }




    }

}
