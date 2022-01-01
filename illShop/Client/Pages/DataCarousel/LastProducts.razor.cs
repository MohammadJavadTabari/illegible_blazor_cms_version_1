using illShop.Shared.Dto.DtosRelatedProduct;
using MudBlazor;

namespace illShop.Client.Pages.DataCarousel
{
    public partial class LastProducts
    {
        public List<ProductDto> ProductDtoList = new();
        protected override async Task OnInitializedAsync()
        {
            ProductDtoList = await _httpRequestHandler.GetListData<ProductDto>("ProductHandlers/GetLastproducts");
        }
        private bool arrows = true;
        private bool bullets = true;
        private bool autocycle = true;
        private Transition transition = Transition.Slide;
    }
}
