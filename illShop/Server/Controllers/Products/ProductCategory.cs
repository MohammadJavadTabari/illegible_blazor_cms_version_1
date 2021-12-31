using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedProduct;
using illShop.Shared.Repositories.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        //[Authorize(Roles = "Administrator")]
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

        [HttpGet]
        [Route("GetPagedProductCategories")]
        public async Task<IActionResult> GetProductCategories([FromQuery] PagingParameters pagingParameters)
        {
            var products = await _productCategoryRepository.GetPagedProductCategories(pagingParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));
            return Ok(products);
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateProductCategory([FromBody] ProductCategoryDto productCategoryDto)
        {
            await _productCategoryRepository.UpdateProductCategory(productCategoryDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteProductCategory([FromRoute] int id)
        {
            await _productCategoryRepository.DeleteProductCategory(id);
            return NoContent();
        }
    }
}
