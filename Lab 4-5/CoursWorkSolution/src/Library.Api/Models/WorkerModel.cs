using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.Models
{
	public class WorkerModel
	{
		public int Id { get; set; }
		[EmailAddress]
		[Required]
		public string Email { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int PositionId { get; set; }
		public string PositionName { get; set; }
	}
}
