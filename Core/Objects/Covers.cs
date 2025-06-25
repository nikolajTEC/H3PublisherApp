namespace REST_API.Objects
{
    public class Covers
    {
        public Covers()
        {
            
        }
        public Covers(string title, bool digitalOnly, int bookId)
        {
            Title = title;
            DigitalOnly = digitalOnly;
            BookId = bookId;
        }

        public int Id { get; set; }
        public string Title { get; set; }   
        public bool DigitalOnly { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }

        public ICollection<ArtistCover> ArtistCovers { get; set; }
    }
}
