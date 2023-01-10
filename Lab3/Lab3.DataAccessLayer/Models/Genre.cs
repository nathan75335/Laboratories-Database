using System.ComponentModel;

namespace Lab3.DataAccessLayer.Models
{
    public class Genre : Model
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}