using EmployeesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Repository
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\SQLExpress;Database=Employees;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasOne(s => s.Department);
        }
    }    
}
