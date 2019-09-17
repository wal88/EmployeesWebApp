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
    public class CreateModel : PageModel
    {
        private readonly IEmployeeApiClient EmployeeApiClient;

        public CreateModel(IEmployeeApiClient employeeApiClient)
        {
            EmployeeApiClient = employeeApiClient;
        }

        public IActionResult OnGet()
        {
            SetDepartments();
            return Page();
        }

        private void SetDepartments()
        {
            ViewData["DepartmentId"] = new SelectList(EmployeeApiClient.GetDepartments().Result, "Id", "Id");
        }

        [BindProperty]
        public Employees Employees { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                SetDepartments();
                return Page();
            }

            await EmployeeApiClient.AddEmployee(Employees);
            return RedirectToPage("./Index");
        }
    }
}