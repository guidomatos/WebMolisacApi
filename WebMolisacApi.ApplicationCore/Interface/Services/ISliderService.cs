using System.Collections.Generic;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.Entities;

namespace WebMolisacApi.ApplicationCore.Interface.Services
{
    public interface ISliderService
    {
        Task<int> GuardarSlider(Slider param);
        Task<int> EliminarSlider(Slider param);
        Task<IEnumerable<Slider>> ObtenerSliders();
        Task<Slider> ObtenerSlider(Slider param);
    }
}