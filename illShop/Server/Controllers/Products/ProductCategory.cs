using illShop.Shared.Dto.DtosRelatedProduct;
using illShop.Shared.Repositories.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace illShop.Server.Controllers.Products
{
    [Route("CategoryHandler")]
    [ApiController]
    public class ProductCategory : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategory(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        [HttpPost]
        [Route("AddProductCategory")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddCategory([FromBody] ProductCategoryDto productCategoryDto)
        {
            var product = await _productCategoryRepository.AddProductCategoryAsync(productCategoryDto);
            return Created("", product);
        }

        [HttpGet]
        [Route("GetProductCategories")]
        public async Task<IActionResult> GetAllCategory()
        {
            var productCategories = await _productCategoryRepository.GetAllProductCategoryAsync();
            return Ok(productCategories); ;
        }
    }
}
