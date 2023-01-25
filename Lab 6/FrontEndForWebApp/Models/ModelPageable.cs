namespace FrontEndForWebApp.Models
{
    public class ModelPageable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfPage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<T> Data { get; set; }
    }
}
