using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMolisacApi.Controllers
{
    /// <summary>
    /// UsuarioController
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuarioController: ControllerBase
    {
        private readonly ILogger<UsuarioController> logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("Get")]
        public string Get() {
            return "ok";
        }

        ///// <summary>
        ///// ValidarLogin
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //[HttpPost("login")]
        //public async Task<IActionResult> ValidarLogin([FromBody]Usuario item)
        //{
        //    try
        //    {
        //        var result = await _usuarioService.ValidarUsuario(item.CodigoUsuario, item.Email, item.ClaveSecreta);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.LogError(default(EventId), ex, ex.Message);
        //        return BadRequest();
        //    }
        //}


    }
}
