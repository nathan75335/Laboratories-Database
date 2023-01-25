using Library.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Library.DataAccess.SeedData;

public class SeedRoles
{
    private readonly RoleManager<Role> _roleManager;

    public SeedRoles(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task seedRolesUsers()
    {
        var list = new List<Role>()
        {
            new Role("User"),
            new Role("Admin")
        };

        var isRoleExist = _roleManager.Roles.Any();

        if (!isRoleExist)
        {
            foreach (var role in list)
            {
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
