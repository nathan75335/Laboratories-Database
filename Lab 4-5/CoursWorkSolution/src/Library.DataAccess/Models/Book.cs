using System.ComponentModel.DataAnnotations;

namespace Library.DataAccess.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public int EditionHouseId { get; set; }
    public EditionHouse EditionHouse;
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public int RegistrationNumber { get; set; }
    [Required]
    public string Name { get; set; }
    public string Author { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int EditionYear { get; set; }
    public string PhotoPath { get; set; }
    public List<BorrowBook> BorrowBooks { get; set; }
}
