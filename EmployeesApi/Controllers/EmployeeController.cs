using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesApi.Models;
using EmployeesApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDAL EmployeeDAL;

        public EmployeeController(IEmployeeDAL employeeDAL)
        {
            EmployeeDAL = employeeDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> Get()
        {
            return await EmployeeDAL.GetEmployees();
        }

        [HttpPost]
        public async Task Post(Employees employee)
        {
            await EmployeeDAL.AddEmployee(employee);
        }

        [HttpPut]
        public async Task Put([FromBody] Employees employee)
        {
            await EmployeeDAL.UpdateEmployee(employee);
        }

        [HttpDelete("{employeeNumber}")]
        public async Task Delete(string employeeNumber)
        {
            await EmployeeDAL.DeleteEmployee(employeeNumber);
        }
    }
}
