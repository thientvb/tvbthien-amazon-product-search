namespace Data.Requests
{
    public class SuggestionRequest
    {
        public int Limit { get; set; } = 11;
        public string Alias { get; set; } = null!;
        public string Prefix { get; set; } = null!;
        public string? Suffix { get; set; } = string.Empty;
    }
}
