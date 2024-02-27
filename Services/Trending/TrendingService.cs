using Data.Requests;

namespace Services.Trending
{
    public class TrendingService : ITrendingService
    {
        private static List<TrendingResponse> _trendingSuggestions = new()
        {
            new TrendingResponse { Keyword = "hat", Count = 2, LastTimeSearch = DateTime.UtcNow },
            new TrendingResponse { Keyword = "jacket", Count = 5, LastTimeSearch = DateTime.UtcNow },
        };

        public void TrackSearch(string? query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var existingTrend = _trendingSuggestions.FirstOrDefault(t => t.Keyword == query.ToLower());

                if (existingTrend != null)
                {
                    // Update existing trend
                    existingTrend.Count++;
                    existingTrend.LastTimeSearch = DateTime.UtcNow;
                }
                else
                {
                    // Add new trend
                    _trendingSuggestions.Add(new TrendingResponse
                    {
                        Keyword = query.ToLower(),
                        Count = 1,
                        LastTimeSearch = DateTime.UtcNow
                    });
                }
            }
        }

        public List<TrendingResponse> GetTrendingSuggestionsWithCounts()
        {
            DateTime threeDaysAgo = DateTime.UtcNow.AddDays(-3);

            return _trendingSuggestions.Where(t => t.LastTimeSearch >= threeDaysAgo)
                                       .OrderByDescending(t => t.Count)
                                       .ThenByDescending(t => t.LastTimeSearch)
                                       .ToList();
        }
    }
}
