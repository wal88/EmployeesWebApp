using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApi.Models
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Departments Department { get; set; }
    }
}
