namespace Data.Requests
{
    public class TrendingResponse
    {
        public string Keyword { get; set; } = null!;
        public int Count { get; set; }
        public DateTime LastTimeSearch { get; set; }
    }
}