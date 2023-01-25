using System.ComponentModel.DataAnnotations;

namespace Library.Api.Models
{
	public class LoginModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(6)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
