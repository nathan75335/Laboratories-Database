using Microsoft.AspNetCore.Identity;

namespace Library.DataAccess.Models;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sexe { get; set; }
    public List<BorrowBook> BorrowBooks { get; set; }
}