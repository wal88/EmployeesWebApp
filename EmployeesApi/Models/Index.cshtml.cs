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
    public class IndexModel : PageModel
    {
        private readonly EmployeesApi.Repository.EmployeeContext _context;

        public IndexModel(EmployeesApi.Repository.EmployeeContext context)
        {
            _context = context;
        }

        public IList<Employees> Employees { get;set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .Include(e => e.Department).ToListAsync();
        }
    }
}
