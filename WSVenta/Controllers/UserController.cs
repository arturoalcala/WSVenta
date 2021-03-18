using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.DBModels.Response;
using WSVenta.Services;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Authentificar([FromBody] AuthRequest model)
        {
            var respuesta = new Respuesta();

            var userResponse = _userService.Auth(model);
            if (userResponse == null)
            {
                respuesta.Message = "El usuario y/o contraseña son incorrectos.";
                return BadRequest(respuesta);
            }

            respuesta.Success = 1;
            respuesta.Data = userResponse;

            return Ok(respuesta);
        }
    }
}
