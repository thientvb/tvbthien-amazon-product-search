using ViewModels.Domain;

namespace Data.Requests
{
    public class SuggestionResponse
    {
        public string Alias { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public List<AmazonSuggestion> Suggestions { get; set; } = new();
        public Guid ResponseId { get; set; } 
    }
}