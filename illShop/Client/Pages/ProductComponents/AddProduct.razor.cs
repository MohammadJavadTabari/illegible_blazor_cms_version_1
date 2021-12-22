using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Authorization;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class AddProduct
    {
        public ProductDto ProductDto = new();

        private async Task Create()
        {
            await _httpRequestHandler.PostAsHttpJsonAsync(ProductDto, "ProductHandlers/AddProduct");
        }
        private void AssignImageUrl(string imgUrl) => ProductDto.ImageUrl = imgUrl;
    }
}
