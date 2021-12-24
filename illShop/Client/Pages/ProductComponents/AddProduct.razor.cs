using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Authorization;
using MudBlazor;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class AddProduct
    {
        public ProductDto ProductDto = new();
        private DateTime? _date = DateTime.Today;
        private async Task Create()
        {
            await _httpRequestHandler.PostAsHttpJsonAsync(ProductDto, "ProductHandlers/AddProduct");
            _snackbar.Add("Image uploaded successfully.", Severity.Success);
        }
        private void AssignImageUrl(string imgUrl) => ProductDto.ImageUrl = imgUrl;
    }
}
