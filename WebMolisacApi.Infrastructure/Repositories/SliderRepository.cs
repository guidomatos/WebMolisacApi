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
    public class SliderRepository : BaseDapper, ISliderRepository
    {
        public SliderRepository(IConfiguration configuration)
            : base(configuration)
        {
        }
        public async Task<int> RegistrarSlider(Slider param)
        {
            int result = 0;

            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                try
                {
                    dbConnection.Open();
                    result = await dbConnection.QueryFirstAsync<int>(
                        "RegistrarSlider",
                        new
                        {
                            param.Nombre,
                            param.Titulo,
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
        public async Task<int> ActualizarSlider(Slider param)
        {
            int result = 0;

            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                try
                {
                    dbConnection.Open();
                    result = await dbConnection.QueryFirstAsync<int>(
                        "ActualizarSlider",
                        new
                        {
                            param.SliderId,
                            param.Nombre,
                            param.Titulo,
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
        public async Task<int> EliminarSlider(Slider param)
        {
            int result = 0;

            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                try
                {
                    dbConnection.Open();
                    result = await dbConnection.QueryFirstAsync<int>(
                        "EliminarSlider",
                        new
                        {
                            param.SliderId,
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
        public async Task<IEnumerable<Slider>> ObtenerSliders()
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                dbConnection.Open();

                var result = await dbConnection.QueryAsync<Slider>(
                    "ObtenerSliders",
                    new
                    {
                        
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 120
                );
                return result.ToList();
            }
        }
        public async Task<Slider> ObtenerSlider(Slider param)
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion())
            {
                dbConnection.Open();

                var result = await dbConnection.QueryFirstAsync<Slider>(
                    "ObtenerSlider",
                    new
                    {
                        param.SliderId
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 120
                );
                return result;
            }
        }
    }

}