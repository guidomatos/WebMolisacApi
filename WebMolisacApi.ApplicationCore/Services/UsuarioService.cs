using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.DTO;
using WebMolisacApi.ApplicationCore.Entities;
using WebMolisacApi.ApplicationCore.Interface.Repositories;
using WebMolisacApi.ApplicationCore.Interface.Services;

namespace WebMolisacApi.ApplicationCore.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<ValidaLogin> ValidarLogin(string codigo, string clave)
        {
            return await this.usuarioRepository.ValidarLogin(codigo, clave);
        }
        public async Task<Usuario> ObtenerDatosSesion(string codigo)
        {
            return await this.usuarioRepository.ObtenerDatosSesion(codigo);
        }

    }
}