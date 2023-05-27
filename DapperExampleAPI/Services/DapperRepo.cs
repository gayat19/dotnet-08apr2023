using Dapper;
using DapperExampleAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace DapperExampleAPI.Services
{
    public class DapperRepo : IDapperRepo
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MyConn");
        }

        public T Add<T>(string query, CommandType commandType, DynamicParameters parameters)
        {
            
            using IDbConnection db = new SqlConnection(_connectionString);
            using IDbTransaction tran = db.BeginTransaction();
            try
            {
                var result = db.Query<T>(query, parameters, commandType: commandType).First();
                tran.Commit();
                return result;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                tran.Rollback();
            }
            return default(T);
        }

        public ICollection<T> Get<T>(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var data = db.Query<T>(query, parameters, commandType: commandType).ToList();
            return data;
        }

        public ICollection<T> GetAll<T>(string query, DynamicParameters parameters, CommandType commandType=CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var data = db.Query<T>(query, parameters, commandType: commandType).ToList();           
            return data;
        }
    }
}
