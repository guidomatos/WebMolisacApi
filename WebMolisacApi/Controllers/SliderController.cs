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
    /// SliderController
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SliderController: ControllerBase
    {
        private readonly ILogger<SliderController> logger;
        private readonly ISliderService sliderService;

        /// <summary>
        /// SliderController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="sliderService"></param>
        public SliderController(ILogger<SliderController> logger, ISliderService sliderService)
        {
            this.logger = logger;
            this.sliderService = sliderService;
        }

        /// <summary>
        /// registrar
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarSlider([FromBody] Slider param)
        {
            try
            {
                var result = await this.sliderService.GuardarSlider(param);
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
        public async Task<IActionResult> ActualizarSlider([FromBody] Slider param)
        {
            try
            {
                var result = await this.sliderService.GuardarSlider(param);
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
        public async Task<IActionResult> EliminarSlider([FromBody] Slider param)
        {
            try
            {
                var result = await this.sliderService.EliminarSlider(param);
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
        public async Task<IActionResult> ObtenerSliders()
        {
            try
            {
                var result = await this.sliderService.ObtenerSliders();
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
        public async Task<IActionResult> ObtenerSlider([FromBody] Slider param)
        {
            try
            {
                var result = await this.sliderService.ObtenerSlider(param);
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
