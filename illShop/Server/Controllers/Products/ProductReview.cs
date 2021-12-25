using illShop.Shared.Dto.DtosRelatedProduct;
using illShop.Shared.Repositories.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace illShop.Server.Controllers.Products
{
    [Route("Review")]
    [ApiController]
    [Authorize]
    public class ProductReview : ControllerBase
    {
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductReview(IProductReviewRepository productReviewRepository, UserManager<IdentityUser> userManager)
        {
            _productReviewRepository = productReviewRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("AddUserReview")]
        public async Task<IActionResult> AddProductReviewRate([FromBody] ProductReviewDto productReviewDto)
        {
            var userName = _userManager.GetUserName(User);
            if (userName == null)
            {
                return BadRequest();
            }
            else
            {
                productReviewDto.UserName = userName;
                productReviewDto.UserId = Guid.Parse(_userManager.GetUserId(User));
                var productReview = await _productReviewRepository.AddProductReviewAsync(productReviewDto);
                return Created("", productReview);
            }
        }
    }
}
