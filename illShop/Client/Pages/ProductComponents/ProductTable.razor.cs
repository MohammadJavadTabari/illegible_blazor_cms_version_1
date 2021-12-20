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
            var url = Path.Combine("/updateProduct/", ProductId.ToString());
            NavigationManager.NavigateTo(url);
        }
    }
}
