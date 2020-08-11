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
    /// PromocionController
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PromocionController: ControllerBase
    {
        private readonly ILogger<PromocionController> logger;
        private readonly IPromocionService promocionService;

        /// <summary>
        /// PromocionController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="promocionService"></param>
        public PromocionController(ILogger<PromocionController> logger, IPromocionService promocionService)
        {
            this.logger = logger;
            this.promocionService = promocionService;
        }

        /// <summary>
        /// registrar
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarPromocion([FromBody] Promocion param)
        {
            try
            {
                var result = await this.promocionService.GuardarPromocion(param);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(default(EventId), ex.StackTrace, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// actualizar
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("actualizar")]
        public async Task<IActionResult> ActualizarPromocion([FromBody] Promocion param)
        {
            try
            {
                var result = await this.promocionService.GuardarPromocion(param);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(default(EventId), ex.StackTrace, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// eliminar
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("eliminar")]
        public async Task<IActionResult> EliminarPromocion([FromBody] Promocion param)
        {
            try
            {
                var result = await this.promocionService.EliminarPromocion(param);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(default(EventId), ex.StackTrace, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// listar
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("listar")]
        public async Task<IActionResult> ObtenerPromociones()
        {
            try
            {
                var result = await this.promocionService.ObtenerPromociones();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(default(EventId), ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// consulta
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("consulta")]
        public async Task<IActionResult> ObtenerPromocion([FromBody] Promocion param)
        {
            try
            {
                var result = await this.promocionService.ObtenerPromocion(param);
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
