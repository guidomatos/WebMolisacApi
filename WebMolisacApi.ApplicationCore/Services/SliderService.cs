using System.Collections.Generic;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.DTO;
using WebMolisacApi.ApplicationCore.Entities;
using WebMolisacApi.ApplicationCore.Interface.Repositories;
using WebMolisacApi.ApplicationCore.Interface.Services;

namespace WebMolisacApi.ApplicationCore.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository SliderRepository;

        public SliderService(ISliderRepository SliderRepository)
        {
            this.SliderRepository = SliderRepository;
        }
        public async Task<int> GuardarSlider(Slider param)
        {
            if (param.SliderId == 0)
                return await SliderRepository.RegistrarSlider(param);
            else
                return await SliderRepository.ActualizarSlider(param);
        }
        public async Task<int> EliminarSlider(Slider param)
        {
            return await SliderRepository.EliminarSlider(param);
        }
        public async Task<IEnumerable<Slider>> ObtenerSliders()
        {
            return await SliderRepository.ObtenerSliders();
        }
        public async Task<Slider> ObtenerSlider(Slider param)
        {
            return await SliderRepository.ObtenerSlider(param);
        }
    }
}