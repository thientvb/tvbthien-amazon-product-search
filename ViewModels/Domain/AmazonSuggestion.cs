namespace ViewModels.Domain
{
    public class AmazonSuggestion
    {
        public string SuggType { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? RefTag { get; set; }
        public string? CandidateSources { get; set; }
        public string? StrategyId { get; set; }
        public string? StrategyApiType { get; set; }
        public double Prior { get; set; }
        public bool Ghost { get; set; }
        public bool Help { get; set; }
    }
}