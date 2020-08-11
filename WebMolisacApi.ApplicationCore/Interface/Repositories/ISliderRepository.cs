using System.Collections.Generic;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.Entities;

namespace WebMolisacApi.ApplicationCore.Interface.Repositories
{
    public interface ISliderRepository
    {
        Task<int> RegistrarSlider(Slider param);
        Task<int> ActualizarSlider(Slider param);
        Task<int> EliminarSlider(Slider param);
        Task<IEnumerable<Slider>> ObtenerSliders();
        Task<Slider> ObtenerSlider(Slider param);
    }
}