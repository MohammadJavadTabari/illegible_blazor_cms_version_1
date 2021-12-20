using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Components;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class ProductTable
    {
        [Parameter]
        public List<ProductDto>? ProductDtoList { get; set; }
        private void RedirectToUpdate(int ProductId)
        {
            NavigationManager.NavigateTo($"/updateProduct/{ProductId}");
        }
    }
}
