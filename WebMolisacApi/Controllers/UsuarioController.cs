using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.Entities;
using WebMolisacApi.ApplicationCore.Interface.Services;

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
        private readonly IUsuarioService usuarioService;

        /// <summary>
        /// UsuarioController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="usuarioService"></param>
        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            this.logger = logger;
            this.usuarioService = usuarioService;
        }

        /// <summary>
        /// ValidarLogin
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> ValidarLogin([FromBody]Usuario item)
        {
            try
            {
                var result = await this.usuarioService.ValidarLogin(item.Codigo, item.Clave);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(default(EventId), ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// codigo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("codigo")]
        public async Task<IActionResult> ObtenerDatosSesion([FromBody] Usuario item)
        {
            try
            {
                var result = await this.usuarioService.ObtenerDatosSesion(item.Codigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(default(EventId), ex, ex.Message);
                return BadRequest();
            }
        }

    }
}
