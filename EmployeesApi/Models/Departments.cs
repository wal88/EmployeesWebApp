using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApi.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
