using Library.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Library.DataAccess.SeedData;

public class SeedDataAdministrator
{
    private readonly UserManager<User> _userManager;

    public SeedDataAdministrator(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task AddAdministrator()
    {
        string password = "NathanMusoko123";

        var user = new User()
        {
            Email = "NathanKaleng@gmail.com",
            LastName = "Musoko",
            FirstName = "Nathan",
            PhoneNumber = "+375256288554",
            UserName = "NatheKaleng",
            Sexe = "M",
            EmailConfirmed = false,
            LockoutEnabled = false,
            TwoFactorEnabled = false,
            AccessFailedCount= 0,
            SecurityStamp = "LUDXP2TE5RJPVHUCQMNQSOTFMPLHAFUH"
        };

        if (!_userManager.Users.ToList().Any())
        {
            await _userManager.CreateAsync(user, password);

            var userLooked = await _userManager.FindByEmailAsync(user.Email);

            await _userManager.AddToRoleAsync(userLooked, new Role("Admin").ToString());
        }
    }
}
