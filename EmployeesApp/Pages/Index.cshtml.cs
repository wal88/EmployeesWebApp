using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesApp.Models;
using EmployeesApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeApiClient EmployeeApiClient;

        public IndexModel(IEmployeeApiClient employeeApiClient)
        {
            EmployeeApiClient = employeeApiClient;
        }

        public IList<Employees> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await EmployeeApiClient.GetEmployees();
        }
    }
}
