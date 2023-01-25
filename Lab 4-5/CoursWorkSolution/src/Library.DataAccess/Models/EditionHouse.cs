using System.ComponentModel.DataAnnotations;

namespace Library.DataAccess.Models;

public class EditionHouse
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string City { get; set; }
    [Required]
    public string Adress { get; set; }

    public List<Book> Books;
}