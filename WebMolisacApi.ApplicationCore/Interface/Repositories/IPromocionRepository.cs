using System.Collections.Generic;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.Entities;

namespace WebMolisacApi.ApplicationCore.Interface.Repositories
{
    public interface IPromocionRepository
    {
        Task<int> RegistrarPromocion(Promocion param);
        Task<int> ActualizarPromocion(Promocion param);
        Task<int> EliminarPromocion(Promocion param);
        Task<IEnumerable<Promocion>> ObtenerPromociones();
        Task<Promocion> ObtenerPromocion(Promocion param);
    }
}