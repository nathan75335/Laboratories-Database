using System.ComponentModel.DataAnnotations;

namespace Library.DataAccess.Models;

public class Worker
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }

    public int PositionId { get; set; }
    public Position Position { get; set; }
    public List<BorrowBook> BorrowBooks { get; set; }
}
