using System.ComponentModel.DataAnnotations;

namespace Library.Api.Models;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

	[Required]
	[DataType(DataType.Text)]
	public string UserName { get; set; }

	[Required]
	[DataType(DataType.Text)]
	public string FirstName { get; set; }

	[Required]
	[DataType(DataType.Text)]
	public string LastName { get; set; }

	[Required]
	[DataType(DataType.Text)]
	public string Sexe { get; set; }
}
