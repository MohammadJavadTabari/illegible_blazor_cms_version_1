using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedProduct;
using illShop.Shared.Repositories.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace illShop.Server.Controllers.Products
{
    [Route("ProductHandlers")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductController(IProductRepository productRepository, UserManager<IdentityUser> userManager)
        {
            _productRepository = productRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("AddProduct")]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product)
        {
            await _productRepository.UpdateProduct(product);
            return NoContent();
        }
        [HttpDelete]
        [Route("RemoveProduct/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}
