using illShop.Client.Shared.Helpers;
using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class ProductDetail
    {
        public ProductDto Product { get; set; } = new();
        public ProductReviewDto ProductReviewDto { get; set; } = new();

        [Parameter]
        public int ProductId { get; set; }

        private int _currentRating;
        private int _reviewCount;
        private int _commentCount;

        protected override async Task OnInitializedAsync()
        {
            Product = await _httpRequestHandler.GetById<ProductDto>(ProductId, "ProductHandlers/GetProductById");
            
            if (Product.ProductReviews != null)
            {
                var reviews = Product.ProductReviews;
                _reviewCount = reviews.Count() ;
                _commentCount = reviews.Where(x => !string.IsNullOrWhiteSpace(x.UserComment)).Count();
                _currentRating = CalculateRating(reviews);
            }
        }
        private int CalculateRating(List<ProductReviewDto> reviews)
        {
            var rating = reviews.Any() ? reviews.Average(r => r.Rate) : 0;
            return Convert.ToInt32(Math.Round(rating));
        }
        
        private async Task RatingValueChanged(int value)
        {
            ProductReviewDto.Rate = value;
            ProductReviewDto.ProductId = ProductId;
            await _httpRequestHandler.PostAsHttpJsonAsync(ProductReviewDto, "Review/AddUserReview");
            _snackbar.Add("Thanks for rating this product",Severity.Info);
        }
    }
}
