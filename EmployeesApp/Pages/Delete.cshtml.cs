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
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeApiClient EmployeeApiClient;

        public DeleteModel(IEmployeeApiClient employeeApiClient)
        {
            EmployeeApiClient = employeeApiClient;
        }

        [BindProperty]
        public Employees Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = (await EmployeeApiClient.GetEmployees()).SingleOrDefault(e => e.EmployeeNumber == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await EmployeeApiClient.DeleteEmployee(id);

            return RedirectToPage("./Index");
        }
    }
}