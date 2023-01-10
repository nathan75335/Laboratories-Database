namespace Lab3.DataAccessLayer.Models
{
    public class Book : Model
    {
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int EditionHouseId { get; set; }

        public EditionHouse EditionHouse { get; set; }

        public string? Name { get; set; }
    }
}
