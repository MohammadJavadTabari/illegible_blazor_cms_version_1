//using illShop.Shared.Dto.DtosRelatedProduct;
//using Microsoft.AspNetCore.Components;

//namespace illShop.Client.Pages.ProductComponents
//{
//    public partial class ProductDetail
//    {
//        public ProductDto Product { get; set; } = new();
       
//        [Parameter]
//        public int ProductId { get; set; }

//        private int _currentRating;
//        private int _reviewCount;
//        private int _questionCount;

//        protected async override Task OnInitializedAsync()
//        {
//            Product = await _httpRequestHandler.GetById<ProductDto>(ProductId, "ProductHandlers/GetProductById");
//            _reviewCount = Product.Reviews.Count;
//            _questionCount = Product.QAs.Count;
//            _currentRating = CalculateRating();
//        }
//        private int CalculateRating()
//        {
//            var rating = Product.Reviews.Any() ? Product.Reviews.Average(r => r.Rate) : 0;
//            return Convert.ToInt32(Math.Round(rating));
//        }
//        private void RatingValueChanged(int value) =>
//            Console.WriteLine($"The product is rated with {value} thumbs.");
//    }
//}
