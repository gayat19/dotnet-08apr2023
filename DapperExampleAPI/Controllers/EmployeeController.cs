using Dapper;
using DapperExampleAPI.Models;
using DapperExampleAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DapperExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDapperRepo _repo;

        public EmployeeController(IDapperRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var result = _repo.GetAll<Employee>("proc_GetAllEmployees", null,CommandType.StoredProcedure);
            return Ok(result);
        }
        [HttpGet("GetByAge")]
        public async Task<ActionResult<List<Employee>>> Get(int age)
        {

            var parameters = new DynamicParameters();
            parameters.Add("age",age,DbType.Int32);
            var result = _repo.GetAll<Employee>("select * from Employees where age > @age", parameters, CommandType.Text);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", employee.Id, DbType.Int32);
            parameters.Add("name", employee.Name, DbType.String);
            parameters.Add("age", employee.Age, DbType.Int32);
            var result = _repo.GetAll<Employee>("proc_InsertEmployee", parameters, CommandType.StoredProcedure);
            return Ok(result);
        }
    }
}
