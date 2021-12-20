using illShop.Shared.Dto.DtosRelatedProduct;
using illShop.Shared.Repositories.Product;
using Microsoft.AspNetCore.Mvc;

namespace illShop.Server.Controllers.Products
{
    [Route("ProductHandlers")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task AddProduct([FromBody] ProductDto productDto)
        {
            await _productRepository.AddProductAsync(productDto);
        }
    }
}
