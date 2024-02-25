using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Helper
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> LoadData<T, U>(String storedProcedure, U parameters, String connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return (List<T>)await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<T> LoadSingle<T, U>(String storedProcedure, U parameters, String connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            var data = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return data.SingleOrDefault();
        }
        public async Task ExecuteQuery<T>(String storedProcedure, T parameters, String connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var result = await connection.ExecuteAsync(storedProcedure, parameters, transaction, commandType: CommandType.StoredProcedure);
                transaction.Commit();
            }
            catch (Exception) { transaction.Rollback(); throw; }
        }
        public async Task<int> ExecuteReturnID<T>(String storedProcedure, T parameters, String connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                int result = await connection.QueryFirstAsync<int>(storedProcedure, parameters, transaction, commandType: CommandType.StoredProcedure);
                transaction.Commit();
                return result;
            }
            catch (Exception) { transaction.Rollback(); throw; }
        }
        public async Task<T> LoginUser<T, U>(String storedProcedure, U parameter, String connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            var result = await connection.QueryAsync<T>(storedProcedure, parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
