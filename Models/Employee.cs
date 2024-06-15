using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RoleEmployee
{
    public class Employee
    {
        public string EmpNo { get; init; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName  => $"{FirstName} {LastName}";
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public ulong Mobile { get; set; }
        public DateOnly JoiningDate { get; set; }
        public Role? Role { get; set; }
        public string Manager { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
    }
}
