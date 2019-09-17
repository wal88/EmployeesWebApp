using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesApp.Models;
using EmployeesApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeesApp.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly IEmployeeApiClient EmployeeApiClient;

        public UpdateModel(IEmployeeApiClient employeeApiClient)
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
            SetDepartments();
            return Page();
        }

        private void SetDepartments()
        {
            ViewData["DepartmentId"] = new SelectList(EmployeeApiClient.GetDepartments().Result, "Id", "Id");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                SetDepartments();
                return Page();
            }

            await EmployeeApiClient.UpdateEmployee(Employee);

            return RedirectToPage("./Index");
        }

        //private bool EmployeesExists(string id)
        //{

        //}
    }
}