using Core.DTO;

namespace H3PublisherApp.Models
{
    public class Book
    {
        public int BooksId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public double BasePrice { get; set; }

        public Cover Cover { get; set; }
    }
}
