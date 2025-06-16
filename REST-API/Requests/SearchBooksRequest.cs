namespace REST_API.Requests
{
    public class SearchBooksRequest
    {
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Price { get; set; }
        public bool Under { get; set; }
    }
}
