using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class ProductTable
    {
        [Parameter]
        public List<ProductDto>? ProductDtoList { get; set; }
        [Parameter]
        public EventCallback<int> OnDeleted { get; set; }
        private void RedirectToUpdate(int ProductId)
        {
            NavigationManager.NavigateTo($"/updateProduct/{ProductId}");
        }
        private async Task Delete(int id)
        {
            var product = ProductDtoList.FirstOrDefault(p => p.ProductId.Equals(id));

            var confirmed = await _JsRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {product.ProductName} product?");
            if (confirmed)
            {
                await OnDeleted.InvokeAsync(id);
            }
        }
    }
}
