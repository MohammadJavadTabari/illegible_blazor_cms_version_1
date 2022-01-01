using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Components;

namespace illShop.Client.Pages.AdminComponents
{
    public partial class UpdateProduct
    {
        [Parameter]
        public int ProductId { get; set; }
        public ProductDto ProductDto = new();
        private DateTime? _date = DateTime.Today;
        private List<ProductCategoryDto> ProductCategoryDtoList = new();
        public int CategoryId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ProductDto = await _httpRequestHandler.GetById<ProductDto>(ProductId, "ProductHandlers/GetProductById");
            ProductCategoryDtoList = await _httpRequestHandler.GetListData<ProductCategoryDto>("CategoryHandler/GetProductCategories");
        }

        private async Task Update()
        {
           await _httpRequestHandler.UpdateByDto(ProductDto, "ProductHandlers/EditProduct");

        }
        private void AssignImageUrl(string imgUrl) => ProductDto.ImageUrl = imgUrl;
    }
}
