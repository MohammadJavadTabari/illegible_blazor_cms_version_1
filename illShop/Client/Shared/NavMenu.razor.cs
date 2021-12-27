using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Components;

namespace illShop.Client.Shared
{
    public partial class NavMenu
    {
        [Parameter]
        public bool SideBarOpen { get; set; }
        public List<ProductCategoryDto> CategoryDtoList { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            CategoryDtoList = await _httpRequestHandler.GetListData<ProductCategoryDto>("CategoryHandler/GetProductCategories");
        }
    }
}
