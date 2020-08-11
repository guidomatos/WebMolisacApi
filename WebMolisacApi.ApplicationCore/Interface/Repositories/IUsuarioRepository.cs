using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.DTO;
using WebMolisacApi.ApplicationCore.Entities;

namespace WebMolisacApi.ApplicationCore.Interface.Repositories
{
    public interface IUsuarioRepository
    {
        Task<ValidaLogin> ValidarLogin(string codigo, string clave);
        Task<Usuario> ObtenerDatosSesion(string codigo);
    }
}