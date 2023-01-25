namespace Library.BusinessLogic.DTO_s;

public class BookDto
{
    public int Id { get; set; }
    public int GenreId { get; set; }
    public int EditionHouseId { get; set; }
    public string EditionHouseName { get; set; }
    public string EditionHouseAdress { get; set; }
    public string EditionHouseCity { get; set; }
    public string GenreName { get; set; }
    public string GenreDescription { get; set; }
    public int RegistrationNumber { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int EditionYear { get; set; }
    public string PhotoPath { get; set; }
}
