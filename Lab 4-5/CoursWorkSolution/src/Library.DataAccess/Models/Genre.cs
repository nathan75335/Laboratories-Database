using System.ComponentModel.DataAnnotations;

namespace Library.DataAccess.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Desctiption { get; set; }
    public List<Book> Books;
}