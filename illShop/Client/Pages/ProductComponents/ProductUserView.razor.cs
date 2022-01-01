using illShop.Shared.Dto.DtosRelatedProduct;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class ProductUserView
    {
        public List<ProductDto> ProductDtoList = new();
        protected override async Task OnInitializedAsync()
        {
            ProductDtoList = await _httpRequestHandler.GetListData<ProductDto>("ProductHandlers/GetAllproducts");
        }

        private void ProductDetail(int id)
        {
            NavigationManager.NavigateTo($"product/{id}");
        }
    }
}
