using Data.Requests;

namespace Services.Trending
{
    public interface ITrendingService
    {
        void TrackSearch(string? query);
        List<TrendingResponse> GetTrendingSuggestionsWithCounts();
    }
}
