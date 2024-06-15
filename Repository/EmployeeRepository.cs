
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoleEmployee;
public class EmployeeRepository : IRepository<Employee>
{
    public IList<Employee> LoadDataFromFile(IList<Employee> _employees , string employeeFile)
    {
        if (File.Exists(employeeFile))
        {
            string jsonData = File.ReadAllText(employeeFile);
            if (jsonData != string.Empty)
            {
                _employees = JsonSerializer.Deserialize<IList<Employee>>(jsonData) ?? new List<Employee>();
            }
        }
        return _employees;
    }
    public bool SaveDataToFile(IList<Employee> _employees, string employeeFile)
    {
        string jsonData = JsonSerializer.Serialize<IList<Employee>>(_employees);
        File.WriteAllText(employeeFile, jsonData);
        return true;
    }
}