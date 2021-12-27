using illShop.Client.Shared.Helpers;
using illShop.Shared.Dto.DtosRelatedProduct;
using MudBlazor;

namespace illShop.Client.Pages.AdminComponents
{
    public partial class AddProduct
    {
        public ProductDto ProductDto = new();
        private DateTime? _date = DateTime.Today;
        private List<ProductCategoryDto> ProductCategoryDtoList = new();
        public int CategoryId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ProductCategoryDtoList = await _httpRequestHandler.GetListData<ProductCategoryDto>("CategoryHandler/GetProductCategories");
        }
        private async Task Create()
        {
            ProductDto.ProductCategoryId = CategoryId;
            await _httpRequestHandler.PostAsHttpJsonAsync(ProductDto, "ProductHandlers/AddProduct");
            await ExecuteDialog();
        }
        private async Task ExecuteDialog()
        {
            var parameters = new DialogParameters
        {
            { "Content", "You have successfully created a new product." },
            { "ButtonColor", Color.Primary },
            { "ButtonText", "OK" }
        };
            var dialog = _dialogService.Show<DialogNotification>("Success", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                bool.TryParse(result.Data.ToString(), out bool shouldNavigate);
                if (shouldNavigate)
                    NavigationManager.NavigateTo("/products");
            }
        }
        private void AssignImageUrl(string imgUrl) => ProductDto.ImageUrl = imgUrl;
    }
}
