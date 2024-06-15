using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RoleEmployee;
/*
 * AddEmployee()
 * EditEmployee()
 * DeleteEmployee()
 * GetAll()
 * SaveUpdatedData()
 */
public interface IEmployeeManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>returns the list of all existing employees</returns>
    IList<Employee> GetAll();

    /// <summary>
    /// Takes an employee and adds it to the employee list.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    Employee AddEmployee(Employee employee);
    /// <summary>
    /// Takes the employee with updated details and edits the details.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns>returns the edited employee</returns>
    Employee EditEmployee(Employee employee);

    /// <summary>
    /// Takes the employee Number and deletes that employee
    /// </summary>
    /// <param name="employee"></param>
    /// <returns>returns the deleted employee</returns>
    Employee DeleteEmployee(string empNo);
    /// <summary>
    /// Updateds the list in the json file.
    /// </summary>
    /// <param name="employees"></param>
    /// <returns></returns>
    bool SaveUpdatedData(IList<Employee> employees);
    
}
