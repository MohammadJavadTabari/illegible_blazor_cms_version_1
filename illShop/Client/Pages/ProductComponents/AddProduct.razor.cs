using illShop.Shared.Dto.DtosRelatedProduct;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class AddProduct
    {
        public ProductDto ProductDto = new();

        private async Task Create()
        {
            await _httpRequestHandler.PostAsHttpJsonAsync(ProductDto, "ProductHandlers/AddProduct");
        }
    }
}
