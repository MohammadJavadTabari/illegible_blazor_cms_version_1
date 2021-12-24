using illShop.Shared.Dto.DtosRelatedProduct;
using illShop.Shared.Repositories.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace illShop.Server.Controllers.Products
{
    [Route("Review")]
    [ApiController]
    [Authorize]
    public class ProductReview : ControllerBase
    {
        private readonly IProductReviewRepository _productReviewRepository;

        public ProductReview(IProductReviewRepository productReviewRepository)
        {
            _productReviewRepository = productReviewRepository;
        }

        [HttpPost]
        [Route("AddUserReview")]
        public async Task<IActionResult> AddProductReview([FromBody] ProductReviewDto productReviewDto)
        {
            var productReview = await _productReviewRepository.AddProductReviewAsync(productReviewDto);
            return Created("", productReview);
        }
    }
}
