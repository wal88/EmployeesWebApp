using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Models
{
    public class Employees
    {
        [MaxLength(5)]
        [Required]
        public string EmployeeNumber { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Department Id is required.")]
        public int DepartmentId { get; set; }

        public Departments Department { get; set; }

        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
    }
}