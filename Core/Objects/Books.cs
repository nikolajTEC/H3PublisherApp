namespace REST_API.Objects
{
    public class Books
    {
        public Books()
        {
            
        }
        public Books(string title, DateOnly publishDate, double basePrice, int authorId)
        {
            Title = title;
            PublishDate = publishDate;
            BasePrice = basePrice;
            AuthorId = authorId;
        }

        public int BooksId { get; set; }
        public string Title { get; set; }
        public DateOnly PublishDate { get; set; }
        public double BasePrice { get; set; }
        public int AuthorId { get; set; }
        public Authors Author { get; set; }

        public int? CoverId { get; set; }
        public Covers Cover { get; set; }
    }
}
