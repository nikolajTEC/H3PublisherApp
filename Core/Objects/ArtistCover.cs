namespace REST_API.Objects
{
    public class ArtistCover
    {
        public int ArtistsId { get; set; }
        public Artists Artist { get; set; }
        public int CoversId { get; set; }
        public Covers Cover { get; set; }
    }
}
