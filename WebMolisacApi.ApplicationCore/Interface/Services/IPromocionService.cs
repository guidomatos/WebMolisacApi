using System.Collections.Generic;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.Entities;

namespace WebMolisacApi.ApplicationCore.Interface.Services
{
    public interface IPromocionService
    {
        Task<int> GuardarPromocion(Promocion param);
        Task<int> EliminarPromocion(Promocion param);
        Task<IEnumerable<Promocion>> ObtenerPromociones();
        Task<Promocion> ObtenerPromocion(Promocion param);
    }
}