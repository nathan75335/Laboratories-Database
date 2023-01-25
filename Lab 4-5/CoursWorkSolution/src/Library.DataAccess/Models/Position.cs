using System.ComponentModel.DataAnnotations;

namespace Library.DataAccess.Models;

public class Position
{
   [Required]
   public int Id { get; set; }
   [Required]
   public string Name { get; set; }

	public List<Worker> Workers { get; set; }
}