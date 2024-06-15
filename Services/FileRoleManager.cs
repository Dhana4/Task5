using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace RoleEmployee;
public class FileRoleManager : IRoleManager
{
    private IList<Role> _roles = new List<Role>();
    private string roleFile = "rolesFile.json";
    RoleRepository RoleRepository = new RoleRepository();
    private int GenerateId()
    {
        IEnumerable<int> roleIds = GetAll().Select(r => r.RoleId);
        if (roleIds.Count() == 0)
        {
            return 1;
        }
        else
        {
            return roleIds.Max() + 1;
        }
    }
    public Role AddRole(Role role)
    {
        _roles = RoleRepository.LoadDataFromFile(_roles, roleFile);
        bool roleAvailable = false;
        Role existingRoleAvailable = new() { };
        foreach (Role existingRole in _roles)
        {
            if (existingRole.Department == role.Department && existingRole.Location == role.Location && existingRole.RoleName == role.RoleName)
            {
                existingRoleAvailable = existingRole;
                roleAvailable = true;
                break;
            }
        }
        if (!roleAvailable)
        {
            Role newRole = new()
            {
                RoleId = GenerateId(),
                RoleName = role.RoleName,
                Department = role.Department,
                Description = role.Description,
                Location = role.Location
            };
            _roles.Add(newRole);
            RoleRepository.SaveDataToFile(_roles, roleFile);
            return newRole;
        }
        else
        {
            return existingRoleAvailable;
        }
    }
    public IList<Role> GetAll()
    {
        _roles = RoleRepository.LoadDataFromFile(_roles, roleFile);
        return _roles;
    }

    public Role? GetRoleById(int id)
    {
        _roles = RoleRepository.LoadDataFromFile(_roles, roleFile);
        return _roles.SingleOrDefault(r => r.RoleId == id);
    }
}
