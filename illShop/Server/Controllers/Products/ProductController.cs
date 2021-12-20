using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedProduct;
using illShop.Shared.Repositories.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var product = await _productRepository.AddProductAsync(productDto);
            return Created("", product);
        }

        [HttpGet("GetPagedProducts")]
        public async Task<IActionResult> GetPagedProducts([FromQuery] PagingParameters pagingParameters)
        {
            var products = await _productRepository.GetPagedBlogPosts(pagingParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));
            return Ok(products);
        }
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _productRepository.GetProduct(id);
            return Ok(product);
        }

        [HttpPut]
        [Route("EditProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product)
        {
            await _productRepository.UpdateProduct(product);
            return NoContent();
        }
    }
}
