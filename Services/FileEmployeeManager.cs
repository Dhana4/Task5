using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace RoleEmployee;
public class FileEmployeeManager : IEmployeeManager
{
    private IList<Employee> _employees = new List<Employee>();
    EmployeeRepository EmployeeRepository = new EmployeeRepository();
    private string employeeFile = "employeesFile.json";
    public Employee AddEmployee(Employee employee)
    {
        _employees = EmployeeRepository.LoadDataFromFile(_employees, employeeFile);
        _employees.Add(employee);
        SaveUpdatedData(_employees);
        return employee;
    }

    public Employee DeleteEmployee(string empNo)
    {
        _employees = EmployeeRepository.LoadDataFromFile(_employees, employeeFile);
        Employee employee = _employees.Single(e => e.EmpNo == empNo);
        _employees.Remove(employee);
        SaveUpdatedData(_employees);
        return employee;
    }

    public Employee EditEmployee(Employee employee)
    {
        _employees = EmployeeRepository.LoadDataFromFile(_employees, employeeFile);
        Employee employeeToUpdate = _employees.Single(e => e.EmpNo == employee.EmpNo);
        int index = _employees.IndexOf(employeeToUpdate);
        _employees[index] = employee;
        SaveUpdatedData(_employees);
        return employeeToUpdate;
    }

    public  IList<Employee> GetAll()
    {
        _employees = EmployeeRepository.LoadDataFromFile(_employees, employeeFile);
        return _employees;
    }
    public bool SaveUpdatedData(IList<Employee> employees)
    {
        EmployeeRepository.SaveDataToFile(employees, employeeFile);
        return true;
    }
}
