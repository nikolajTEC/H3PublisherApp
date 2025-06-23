namespace Core.DTO
{
	public class BookDTO
    {
        public int AuthorId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly PublishDate { get; set; }
        public double BasePrice { get; set; }

        public CoverDTO Cover { get; set; }
    }
}
