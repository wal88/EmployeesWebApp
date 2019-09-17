using EmployeesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Repository
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly EmployeeContext employeeContext;

        public EmployeeDAL(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public async Task<List<Employees>> GetEmployees()
        {
            var employees = await this.employeeContext.Employees.Include(e => e.Department).ToListAsync();
            return employees;
        }

        public async Task AddEmployee(Employees employee)
        {
            employee.EmployeeNumber = "10002";
            await this.employeeContext.Employees.AddAsync(employee);
            await employeeContext.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employees employee)
        {
            var employeeNumber = employee?.EmployeeNumber;
            var rowToUpdate = this.employeeContext.Employees.SingleOrDefault(e => e.EmployeeNumber == employeeNumber);
            if (rowToUpdate != null)
            {
                rowToUpdate = employee;
                await employeeContext.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployee(string employeeNumber)
        {
            var rowToDelete = this.employeeContext.Employees.SingleOrDefault(e => e.EmployeeNumber == employeeNumber);
            if (rowToDelete != null)
            {
                this.employeeContext.Employees.Remove(rowToDelete);
                await employeeContext.SaveChangesAsync();
            }
        }

        public async Task<List<Departments>> GetDepartments()
        {
            var departments = await this.employeeContext.Departments.ToListAsync();
            return departments;
        }
    }

    public interface IEmployeeDAL
    {
        Task<List<Employees>> GetEmployees();
        Task AddEmployee(Employees employee);
        Task UpdateEmployee(Employees employee);
        Task DeleteEmployee(string employeeNumber);
        Task<List<Departments>> GetDepartments();
    }
}
