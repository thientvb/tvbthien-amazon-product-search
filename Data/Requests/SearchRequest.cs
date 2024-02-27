namespace Data.Requests
{
    public class SearchRequest
    {
        public string Alias { get; set; } = "aps";
        public string? SearchText { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public double? Rating { get; set; }
        public List<string>? Brands { get; set; }
        public List<string>? PremiumBrands { get; set; }
        public List<string>? TopBrands { get; set; }
        public bool? AllDiscounts { get; set; }
        public bool? TodaysDeals { get; set; }
        public List<string>? CareInstructions { get; set; }
        public List<string>? FitTypes { get; set; }
        public List<string>? SpecialFeatures { get; set; }
        public List<string>? Occasions { get; set; }
        public string? BusinessType { get; set; }
        public List<string>? Colors { get; set; }
        public List<string>? Themes { get; set; }
        public bool? IsAmazonGlobalStore { get; set; }
        public bool? IncludeOutOfStock { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 20;
    }
}
