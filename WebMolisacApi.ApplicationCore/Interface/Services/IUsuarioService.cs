using System.Collections.Generic;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.DTO;
using WebMolisacApi.ApplicationCore.Entities;

namespace WebMolisacApi.ApplicationCore.Interface.Services
{
    public interface IUsuarioService
    {
        Task<ValidaLogin> ValidarLogin(string codigo, string clave);
        Task<Usuario> ObtenerDatosSesion(string codigo);
    }
}
