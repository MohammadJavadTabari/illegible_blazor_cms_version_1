﻿using illShop.Shared.Dto.DtosRelatedProduct;
using Microsoft.AspNetCore.Components;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class UpdateProduct
    {
        private ProductDto _product;

        [Parameter]
        public int ProductId { get; set; }
        protected async override Task OnInitializedAsync()
        {
            _product = await _httpRequestHandler.GetById<ProductDto>(ProductId, "ProductHandlers/GetProductById");
        }
        private async Task Update()
        {
            await _httpRequestHandler.UpdateByDto(_product, "ProductHandlers/EditProduct");
        }
        private void AssignImageUrl(string imgUrl) => _product.ImageUrl = imgUrl;
    }
}
