using System.Collections.Generic;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.DTO;
using WebMolisacApi.ApplicationCore.Entities;
using WebMolisacApi.ApplicationCore.Interface.Repositories;
using WebMolisacApi.ApplicationCore.Interface.Services;

namespace WebMolisacApi.ApplicationCore.Services
{
    public class PromocionService : IPromocionService
    {
        private readonly IPromocionRepository promocionRepository;

        public PromocionService(IPromocionRepository promocionRepository)
        {
            this.promocionRepository = promocionRepository;
        }
        public async Task<int> GuardarPromocion(Promocion param)
        {
            if (param.PromocionId == 0)
                return await promocionRepository.RegistrarPromocion(param);
            else
                return await promocionRepository.ActualizarPromocion(param);
        }
        public async Task<int> EliminarPromocion(Promocion param)
        {
                return await promocionRepository.EliminarPromocion(param);
        }
        public async Task<IEnumerable<Promocion>> ObtenerPromociones()
        {
            return await promocionRepository.ObtenerPromociones();
        }
        public async Task<Promocion> ObtenerPromocion(Promocion param)
        {
            return await promocionRepository.ObtenerPromocion(param);
        }
    }
}