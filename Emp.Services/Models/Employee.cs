using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Services.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int Emp_no { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Gender { get; set; }
        public string Emp_Address { get; set; }
        public string Emp_Department { get; set; }
        public string Emp_Position { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Emp_Email { get; set; }
    }
}
