using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesApi.Models;
using EmployeesApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApi.Controllers
{
    [Route("api/employee/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IEmployeeDAL EmployeeDAL;

        public DepartmentsController(IEmployeeDAL employeeDAL)
        {
            EmployeeDAL = employeeDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departments>>> Get()
        {
            return await EmployeeDAL.GetDepartments();
        }
    }
}
