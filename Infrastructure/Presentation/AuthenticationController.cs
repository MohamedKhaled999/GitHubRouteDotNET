using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Services.Abstractions;
using Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    
}
