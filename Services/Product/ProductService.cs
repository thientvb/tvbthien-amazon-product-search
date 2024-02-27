using Newtonsoft.Json;
using ViewModels.Domain;

namespace Services.Product
{
    public class ProductService : IProductService
    {
        public List<AmazonAlias> GetAmazonAliases()
        {
            try
            {
                string filePath = Path.Combine("..", "Data", "DataSample", "AmazonAlias.json");
                string json = File.ReadAllText(filePath);
                List<AmazonAlias>? amazonAmazonAliases = JsonConvert.DeserializeObject<List<AmazonAlias>>(json);

                return amazonAmazonAliases ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                throw;
            }
        }
    }
}
