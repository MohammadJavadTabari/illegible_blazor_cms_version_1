using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedProduct;

namespace illShop.Client.Pages.ProductComponents
{
    public partial class Products
    {
        public List<ProductDto> ProductDtoList { get; set; } = new ();
        public MetaData MetaData { get; set; } = new MetaData();
        private PagingParameters _pagingParameters = new ();

        private async Task GetProducts()
        {
            var pagingResponse = await _httpRequestHandler.GetPagedData(_pagingParameters, "ProductHandlers/GetPagedProducts");
            ProductDtoList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
        protected async override Task OnInitializedAsync()
        {
            await GetProducts();
        }
        private async Task SelectedPage(int page)
        {
            _pagingParameters.PageNumber = page;
            await GetProducts();
        }
        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _pagingParameters.PageNumber = 1;
            _pagingParameters.SearchTerm = searchTerm;
            await GetProducts();
        }
        private async Task SortChanged(string orderBy)
        {
            Console.WriteLine(orderBy);
            _pagingParameters.OrderBy = orderBy;
            await GetProducts();
        }
        private async Task DeleteProduct(int id)
        {
            await _httpRequestHandler.DeleteById(id, "ProductHandlers/RemoveProduct");
            _pagingParameters.PageNumber = 1;
            await GetProducts();
        }
    }
}
