using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WebMolisacApi.Infrastructure.Connection.Dapper
{
    public class Sql: BaseDapper
    {
        public Sql(IConfiguration _configuration) : base(_configuration)
        {
            _dapperConfiguration = _configuration;
        }

        static internal IDbConnection ObtenerConexion()
        {
            string connectionStringName = "ConnectionStrings:ConexionServidorBD";

            var connectionString = _dapperConfiguration[connectionStringName];

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("El parámetro connectionString se encuentra nulo.");

            return new SqlConnection(connectionString);
        }        
    }
}
