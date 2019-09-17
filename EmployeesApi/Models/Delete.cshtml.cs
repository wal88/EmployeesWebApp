using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeesApi.Repository;

namespace EmployeesApi.Models
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeesApi.Repository.EmployeeContext _context;

        public DeleteModel(EmployeesApi.Repository.EmployeeContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employees = await _context.Employees.FindAsync(id);

            if (Employees != null)
            {
                _context.Employees.Remove(Employees);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
