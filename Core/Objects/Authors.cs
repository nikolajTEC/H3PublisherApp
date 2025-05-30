namespace REST_API.Objects
{
    public class Authors
    {
        public Authors(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
