using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAdmin.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {

        private IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Authenticate([FromBody]UserEntity userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Error al relizar el proceso de autenticacion" });

            return Ok(user);
        }
    }
}