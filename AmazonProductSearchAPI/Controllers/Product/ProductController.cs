using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Product;
using ViewModels.Domain;

namespace AmazonProductSearchAPI.Controllers.Product
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("aliases")]
        public ActionResult<List<AmazonAlias>> GetAmazonAliases()
        {
            List<AmazonAlias> amazonAliases = _productService.GetAmazonAliases();
            return Ok(amazonAliases);
        }
    }
}
