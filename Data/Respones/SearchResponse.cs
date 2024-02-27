using ViewModels.Domain;

namespace Data.Requests
{
    public class SearchResponse
    {
        public List<AmazonProduct> AmazonProducts { get; set; } = new();
    }
}