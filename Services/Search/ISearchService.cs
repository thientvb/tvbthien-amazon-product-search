using Data.Requests;

namespace Services.Search
{
    public interface ISearchService
    {
        SearchResponse SearchAmazonProduct(SearchRequest req);
        SuggestionResponse GetSuggestions(SuggestionRequest req);
    }
}
