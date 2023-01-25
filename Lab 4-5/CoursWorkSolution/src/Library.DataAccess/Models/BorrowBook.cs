using System.ComponentModel.DataAnnotations;

namespace Library.DataAccess.Models;

public class BorrowBook
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int BookId { get; set; }
    public Book Book { get; set; }
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    public  Worker Worker { get; set; }
    [Required]
    public int WorkerId { get; set; }
    public DateTime GivenDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
