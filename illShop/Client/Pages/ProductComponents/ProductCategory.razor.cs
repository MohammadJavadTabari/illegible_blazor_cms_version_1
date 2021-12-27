using illShop.Shared.Dto.DtosRelatedProduct;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class ProductCategory
    {
        public ProductCategoryDto ProductCategoryDto = new();
        private async Task Create()
        {
            await _httpRequestHandler.PostAsHttpJsonAsync(ProductCategoryDto, "CategoryHandler/AddProductCategory");
            _snackbar.Add("Product Category Added Successfully",MudBlazor.Severity.Success);
        }
    }
}