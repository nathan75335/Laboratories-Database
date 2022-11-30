
namespace BookProject
{
    public class Book
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Author { get; set; }

        public EditionHouse EditionHouse { get; set; }

        public int EditionHouseId { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }
    }
}
