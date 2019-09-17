using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeesApi.Repository;

namespace EmployeesApi.Models
{
    public class CreateModel : PageModel
    {
        private readonly EmployeesApi.Repository.EmployeeContext _context;

        public CreateModel(EmployeesApi.Repository.EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Employees Employees { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}