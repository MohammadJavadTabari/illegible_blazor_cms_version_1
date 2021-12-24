using illShop.Client.Shared.Helpers;
using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class ProductDetail
    {
        public ProductDto Product { get; set; } = new();

        [Parameter]
        public int ProductId { get; set; }

        private int _currentRating;
        private int _reviewCount;
        private int _questionCount;

        protected async override Task OnInitializedAsync()
        {
            Product = await _httpRequestHandler.GetById<ProductDto>(ProductId, "ProductHandlers/GetProductById");
            
            if (Product.ProductReviews != null)
            {
                var reviews = Product.ProductReviews;
                _reviewCount = reviews.Count() ;
                _questionCount =reviews.Where(x => string.IsNullOrWhiteSpace(x.UserComment)).Count();
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
            
        }
    }
}
