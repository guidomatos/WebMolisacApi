using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebMolisacApi.ApplicationCore.Entities;
using WebMolisacApi.ApplicationCore.Interface.Repositories;
using WebMolisacApi.Infrastructure.Connection.Dapper;
// using WebMolisacApi.Infrastructure.Repositories.Extensions;

namespace WebMolisacApi.Infrastructure.Repositories
{
    public class PromocionRepository : BaseDapper, IPromocionRepository
    {
        public PromocionRepository(IConfiguration configuration)
            : base(configuration)
        {
        }
        public async Task<int> RegistrarPromocion(Promocion param)
        {
            int result = 0;

            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                try
                {
                    dbConnection.Open();
                    result = await dbConnection.QueryFirstAsync<int>(
                        "RegistrarPromocion",
                        new
                        {
                            param.Nombre,
                            param.Descripcion,
                            param.Imagen,
                            param.UsuarioCreacion
                        },
                        commandType: CommandType.StoredProcedure
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
        public async Task<int> ActualizarPromocion(Promocion param)
        {
            int result = 0;

            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                try
                {
                    dbConnection.Open();
                    result = await dbConnection.QueryFirstAsync<int>(
                        "ActualizarPromocion",
                        new
                        {
                            param.PromocionId,
                            param.Nombre,
                            param.Descripcion,
                            param.Imagen,
                            param.UsuarioModificacion
                        },
                        commandType: CommandType.StoredProcedure
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
        public async Task<int> EliminarPromocion(Promocion param)
        {
            int result = 0;

            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                try
                {
                    dbConnection.Open();
                    result = await dbConnection.QueryFirstAsync<int>(
                        "EliminarPromocion",
                        new
                        {
                            param.PromocionId,
                            param.UsuarioModificacion
                        },
                        commandType: CommandType.StoredProcedure
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
        public async Task<IEnumerable<Promocion>> ObtenerPromociones()
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                dbConnection.Open();

                var result = await dbConnection.QueryAsync<Promocion>(
                    "ObtenerPromociones",
                    new
                    {
                        
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 120
                );
                return result.ToList();
            }
        }
        public async Task<Promocion> ObtenerPromocion(Promocion param)
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                dbConnection.Open();

                var result = await dbConnection.QueryFirstAsync<Promocion>(
                    "ObtenerPromocion",
                    new
                    {
                        param.PromocionId
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 120
                );
                return result;
            }
        }
    }

}