
namespace BookProject
{
    public class EditionHouse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public List<Book> Books { get; set; }
    }
}
