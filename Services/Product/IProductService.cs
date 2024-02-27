using ViewModels.Domain;

namespace Services.Product
{
    public interface IProductService
    {
        List<AmazonAlias> GetAmazonAliases();
    }
}
