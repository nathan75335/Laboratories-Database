namespace FrontEndForWebApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// The id of the book
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the book
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The genres of the book
        /// </summary>
        public List<GenreDto> Genres { get; set; }
    }
}
