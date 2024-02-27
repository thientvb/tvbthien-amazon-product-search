namespace ViewModels.Domain
{
    public class AmazonProduct
    {
        public Guid Id { get; set; }
        public string Alias { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? PriceDiscounted { get; set; }
        public double? Rating { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public string? Author { get; set; }
        public int NumberOfReviews { get; set; }
        public List<string> PremiumBrands { get; set; } = new();
        public List<string> TopBrands { get; set; } = new();
        public bool AllDiscounts { get; set; }
        public bool TodaysDeals { get; set; }
        public List<string> CareInstructions { get; set; } = new();
        public List<string> FitTypes { get; set; } = new();
        public List<string> SpecialFeatures { get; set; } = new();
        public List<string> Occasions { get; set; } = new();
        public string BusinessType { get; set; } = string.Empty;
        public List<string> Colors { get; set; } = new();
        public List<string> Themes { get; set; } = new();
        public bool IsAmazonGlobalStore { get; set; }
        public bool IncludeOutOfStock { get; set; }
        public string? MainImage { get; set; }
        public List<string> Images { get; set; } = new();
    }
}
