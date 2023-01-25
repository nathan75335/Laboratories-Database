using Microsoft.AspNetCore.Identity;

namespace Library.DataAccess.Models;

public class Role : IdentityRole<int>
{
    public Role(string name) : base(name)
    {
        
    }

    public Role()
    {
        base.Name = "User";
    }
}