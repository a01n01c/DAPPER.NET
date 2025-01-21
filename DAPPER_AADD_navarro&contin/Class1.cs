using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Compilation;
using Dapper;
using Microsoft.Extensions.Configuration;
using DAPPER_AADD_navarro_contin.Datos;

namespace DAPPER_AADD_navarro_contin
{
    public class VehiculoRepository
    {
        private readonly string connectionString;

        public VehiculoRepository()
        {
            var configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Vehiculos>> GetAllVehiculosAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehiculos";
                return await connection.QueryAsync<Vehiculos>(query);
            }
        }


        public async Task<Vehiculos> GetVehiculoByIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehiculos WHERE id_vehiculo = @Id";
                return await connection.QueryFirstOrDefaultAsync<Vehiculos>(query, new { Id = id });
            }
        }

        public async Task<int> AddVehiculoAsync(Vehiculos vehiculo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO Vehiculos (id_modelo, color, precio, anio, disponible)
                VALUES (@id_modelo, @color, @precio, @anio, @disponible);
                SELECT CAST(SCOPE_IDENTITY() as int)";
                return await connection.ExecuteScalarAsync<int>(query, vehiculo);
            }
        }

        public async Task<bool> UpdateVehiculoAsync(Vehiculos vehiculo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE Vehiculos
                SET id_Modelo = @id_Modelo, 
                    color = @color, 
                    precio = @precio, 
                    anio = @anio, 
                    disponible = @disponible
                WHERE id_vehiculo = @id_vehiculo";
                int rowsAffected = await connection.ExecuteAsync(query, vehiculo);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteVehiculoAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Vehiculos WHERE id_vehiculo = @id";
                int rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }
        }}
