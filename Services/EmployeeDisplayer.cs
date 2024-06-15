using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoleEmployee;

public class EmployeeDisplayer
{
    private  readonly IEmployeeManager employeeManager;
    private IList<Employee> _employees = new List<Employee>();
    public EmployeeDisplayer(IEmployeeManager employeeManager)
    {
        this.employeeManager = employeeManager;
        _employees = employeeManager.GetAll();
    }
    
    public void DisplayAll()
    {
        _employees = employeeManager.GetAll();
        foreach (Employee employee in _employees)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Employee Number: {employee.EmpNo}");
            Console.WriteLine($"Name: {employee.FullName}");
            if (employee.Role is not null)
            {
                Console.WriteLine($"Role: {employee.Role.RoleName}");
                Console.WriteLine($"Department: {employee.Role.Department}");
                Console.WriteLine($"Location: {employee.Role.Location}");
            }
            Console.WriteLine($"Joining Date: {employee.JoiningDate}");
            Console.WriteLine($"Manager Name: {employee.Manager}");
            Console.WriteLine($"Project Name: {employee.Project}");
            Console.WriteLine("-----------------------------------");
        }
    }
    public void DisplayOne(string empNo)
    {
        _employees = employeeManager.GetAll();
        Employee employee = _employees.Single(e => e.EmpNo == empNo);
        PropertyInfo[] properties = typeof(Employee).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            var value = property.GetValue(employee);
            if (value is Role role)
            {
                Console.WriteLine($"Job Title: {role.RoleName}");
                Console.WriteLine($"Department: {role.Department}");
                Console.WriteLine($"Location: {role.Location}");
            }
            else
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(employee)}");
            }
        }
    }
    public void DisplayAllEmployeesInRole(int roleId)
    {
        bool empPresent = false;
        IList<Employee> employees = employeeManager.GetAll();
        foreach (Employee employee in employees)
        {
            if (employee.Role?.RoleId == roleId)
            {
                if (!empPresent)
                {
                    Console.WriteLine($"Employees in role {roleId}");
                }
                empPresent = true;
                Console.WriteLine($"{employee.EmpNo}-------{employee.FullName}");
            }
        }
        if (empPresent == false)
        {
            Console.WriteLine("No Employees Found with this Role");
        }
    }
}
