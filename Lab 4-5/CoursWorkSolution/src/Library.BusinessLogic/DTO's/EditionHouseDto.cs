using System.ComponentModel.DataAnnotations;

namespace Library.BusinessLogic.DTO_s;

public class EditionHouseDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Adress { get; set; }
}
