using Dapper;
using DapperExampleAPI.Models;
using System.Data;

namespace DapperExampleAPI.Services
{
    public interface IDapperRepo
    {
        public T Add<T>(string query, CommandType commandType, DynamicParameters parameters);
        public ICollection<T> GetAll<T>(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        public ICollection<T> Get<T>(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
