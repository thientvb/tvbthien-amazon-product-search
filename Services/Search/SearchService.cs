using Data.Requests;
using Newtonsoft.Json;
using System.Linq;
using ViewModels.Domain;

namespace Services.Search
{
    public class SearchService : ISearchService
    {
        public SearchService() { }

        public SearchResponse SearchAmazonProduct(SearchRequest searchRequest)
        {
            try
            {
                string filePath = Path.Combine("..", "Data", "DataSample", "AmazonProduct.json");
                string json = File.ReadAllText(filePath);

                // Deserialize JSON to a list of AmazonProduct objects
                List<AmazonProduct> amazonProducts = JsonConvert.DeserializeObject<List<AmazonProduct>>(json)!;

                IQueryable<AmazonProduct> query = amazonProducts.AsQueryable();

                // Apply search criteria
                if (!string.IsNullOrEmpty(searchRequest.SearchText))
                {
                    query = query.Where(p =>
                        p.Title.Contains(searchRequest.SearchText, StringComparison.OrdinalIgnoreCase) ||
                        (p.Description != null && p.Description.Contains(searchRequest.SearchText, StringComparison.OrdinalIgnoreCase)) ||
                        (p.Brand != null && p.Brand.Contains(searchRequest.SearchText, StringComparison.OrdinalIgnoreCase))
                    );
                }

                // aps is "All Departments"
                if (!string.IsNullOrEmpty(searchRequest.Alias) && searchRequest.Alias != "aps")
                {
                    query = query.Where(p => p.Alias.Contains(searchRequest.Alias, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(searchRequest.Title))
                {
                    query = query.Where(p => p.Title.Contains(searchRequest.Title, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(searchRequest.Category))
                {
                    query = query.Where(p => p.Category == searchRequest.Category);
                }

                if (searchRequest.Rating.HasValue)
                {
                    query = query.Where(p => p.Rating.HasValue && p.Rating.Value >= searchRequest.Rating.Value);
                }

                if (searchRequest.PriceMin.HasValue || searchRequest.PriceMax.HasValue)
                {
                    query = query.Where(p =>
                        (searchRequest.PriceMin == null || (p.Price >= searchRequest.PriceMin.Value || (p.PriceDiscounted.HasValue && p.PriceDiscounted >= searchRequest.PriceMin.Value))) &&
                        (searchRequest.PriceMax == null || (p.Price <= searchRequest.PriceMax.Value || (p.PriceDiscounted.HasValue && p.PriceDiscounted <= searchRequest.PriceMax.Value)))
                    );
                }

                // Apply additional search criteria from SearchRequest
                if (searchRequest.Brands?.Any() == true)
                {
                    query = query.Where(p => searchRequest.Brands.Contains(p.Brand, StringComparer.OrdinalIgnoreCase));
                }

                if (searchRequest.PremiumBrands?.Any() == true)
                {
                    query = query.Where(p => p.PremiumBrands.Any(brand => searchRequest.PremiumBrands.Contains(brand, StringComparer.OrdinalIgnoreCase)));
                }

                if (searchRequest.TopBrands?.Any() == true)
                {
                    query = query.Where(p => p.TopBrands.Any(brand => searchRequest.TopBrands.Contains(brand, StringComparer.OrdinalIgnoreCase)));
                }

                if (searchRequest.AllDiscounts != null)
                {
                    query = query.Where(p => p.AllDiscounts);
                }

                if (searchRequest.TodaysDeals != null)
                {
                    query = query.Where(p => p.TodaysDeals);
                }

                if (searchRequest.Colors?.Any() == true)
                {
                    query = query.Where(p => p.Colors.Any(b => searchRequest.Colors.Contains(b, StringComparer.OrdinalIgnoreCase)));
                }

                if (searchRequest.Themes?.Any() == true)
                {
                    query = query.Where(p => p.Themes.Any(b => searchRequest.Themes.Contains(b, StringComparer.OrdinalIgnoreCase)));
                }

                if (searchRequest.IsAmazonGlobalStore != null)
                {
                    query = query.Where(p => p.IsAmazonGlobalStore);
                }

                if (searchRequest.IncludeOutOfStock != null)
                {
                    query = query.Where(p => p.IncludeOutOfStock);
                }

                // Pagination
                query = query.Skip(searchRequest.Skip).Take(searchRequest.Take);

                var res = new SearchResponse { AmazonProducts = query.ToList() };

                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                throw;
            }
        }

        public SuggestionResponse GetSuggestions(SuggestionRequest suggestionRequest)
        {
            try
            {
                string filePath = Path.Combine("..", "Data", "DataSample", "AmazonSuggestion.json");
                string json = File.ReadAllText(filePath);

                // Deserialize JSON to a list of AmazonProduct objects
                List<AmazonSuggestion> suggestions = JsonConvert.DeserializeObject<List<AmazonSuggestion>>(json)!;

                SuggestionResponse res = new()
                {
                    Alias = suggestionRequest.Alias,
                    Prefix = suggestionRequest.Prefix,
                    Suffix = suggestionRequest.Suffix ?? string.Empty,
                    Suggestions = suggestions.Where(x => x.Value.Contains(suggestionRequest.Prefix, StringComparison.OrdinalIgnoreCase)).Take(suggestionRequest.Limit).ToList(),
                    ResponseId = Guid.NewGuid()
                };

                return res;
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                throw;
            }
        }
    }
}
