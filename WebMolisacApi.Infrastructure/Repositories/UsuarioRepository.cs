using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.DTO;
using WebMolisacApi.ApplicationCore.Entities;
using WebMolisacApi.ApplicationCore.Interface.Repositories;
using WebMolisacApi.Infrastructure.Connection.Dapper;
using SQL = WebMolisacApi.Infrastructure.Connection.Dapper.Sql;

namespace WebMolisacApi.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseDapper, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<ValidaLogin> ValidarLogin(string codigo, string clave)
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<ValidaLogin>(
                    "ValidarLogin",
                    new { Codigo = codigo, Clave = clave },
                    commandType: CommandType.StoredProcedure
                );

                return result.FirstOrDefault();
            }
        }

        public async Task<Usuario> ObtenerDatosSesion(string codigo)
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<Usuario>(
                    "ObtenerDatosSesion",
                    new { Codigo = codigo },
                    commandType: CommandType.StoredProcedure
                );

                return result.FirstOrDefault();
            }
        }
        
    }
}