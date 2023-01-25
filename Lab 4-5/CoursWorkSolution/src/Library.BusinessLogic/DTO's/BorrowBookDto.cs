using Library.DataAccess.Models;

namespace Library.BusinessLogic.DTO_s;

public class BorrowBookDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public  Worker Worker { get; set; }
    public int WorkerId { get; set; }
	public DateTime GivenDate { get; set; }
	public DateTime ReturnDate { get; set; }
}
