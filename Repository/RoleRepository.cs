using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoleEmployee;
public class RoleRepository : IRepository<Role>
{
    public IList<Role> LoadDataFromFile(IList<Role> _roles, string roleFile)
    {
        if (File.Exists(roleFile))
        {
            string jsonData = File.ReadAllText(roleFile);
            _roles = JsonSerializer.Deserialize<IList<Role>>(jsonData) ?? new List<Role>();
        }
        return _roles;
    }

    public bool SaveDataToFile(IList<Role> _roles, string roleFile)
    {
        string jsonData = JsonSerializer.Serialize<IList<Role>>(_roles);
        File.WriteAllText(roleFile, jsonData);
        return true;
    }
}
