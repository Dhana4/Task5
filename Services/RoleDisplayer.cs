using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace RoleEmployee;
public class RoleDisplayer
{
    private readonly IRoleManager roleManager;
    IList<Role> _roles = new List<Role>();
    public RoleDisplayer(IRoleManager roleManager)
    {
        this.roleManager = roleManager;
       _roles = roleManager.GetAll();
    }
    public void DisplayAll()
    {
        foreach (Role role in _roles)
        {
            string dashedLine = "--------------------------------------\n";
            Console.WriteLine(dashedLine);
            Console.WriteLine($"Role ID : {role.RoleId}");
            Console.WriteLine($"Role Name: {role.RoleName}");
            Console.WriteLine($"Department: {role.Department}");
            Console.WriteLine($"Location: {role.Location}");
            Console.WriteLine(dashedLine);

        }
    }
}
