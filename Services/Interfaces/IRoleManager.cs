using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleEmployee;
/*
 * AddRole()
 * DisplayAll()
 * GetAll()
 */
public interface IRoleManager
{
    /// <summary>
    /// Takes the role and add it to the list
    /// </summary>
    /// <param name="role"></param>
    /// <returns>reurns the role added</returns>
    Role AddRole(Role role);
    /// <summary>
    /// Gets the role by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Role matching the ID, null otherwise</returns>
    Role? GetRoleById(int id);
    /// <summary>
    /// It returns all the roles.
    /// </summary>
    IList<Role> GetAll();  
}
