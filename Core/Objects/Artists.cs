namespace REST_API.Objects
{
    public class Artists
    {
        public Artists()
        {
            
        }
        public Artists(string firstname, string lastName)
        {
            FirstName = firstname;
            LastName = lastName;
        }

        public int ArtistsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ArtistCover> ArtistCovers { get; set; }
    }
}
