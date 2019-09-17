using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesApi.Repository;

namespace EmployeesApi.Models
{
    public class EditModel : PageModel
    {
        private readonly EmployeesApi.Repository.EmployeeContext _context;

        public EditModel(EmployeesApi.Repository.EmployeeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employees Employees { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employees = await _context.Employees
                .Include(e => e.Department).FirstOrDefaultAsync(m => m.EmployeeNumber == id);

            if (Employees == null)
            {
                return NotFound();
            }
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(Employees.EmployeeNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeesExists(string id)
        {
            return _context.Employees.Any(e => e.EmployeeNumber == id);
        }
    }
}
