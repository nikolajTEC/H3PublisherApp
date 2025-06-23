using Core.DTO;

namespace H3PublisherApp.Models
{
    public class Cover
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool DigitalOnly { get; set; }

        public List<Artist> Artists { get; set; }
    }
}
