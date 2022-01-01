using illShop.Client.Shared.Helpers;
using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedProduct;
using MudBlazor;

namespace illShop.Client.Pages.AdminComponents
{
    public partial class Products
    {
        private MudTable<ProductDto>? _table = new();
        private PagingParameters _pagingParameters = new();
        private readonly int[] _pageSizeOption = { 4, 6, 10 };
        private async Task<TableData<ProductDto>> GetServerData(TableState state)
        {
            _pagingParameters.PageSize = state.PageSize;
            _pagingParameters.PageNumber = state.Page + 1;
            state.SortDirection = SortDirection.Descending;
            _pagingParameters.OrderBy = state.SortDirection == SortDirection.Descending ?
            state.SortLabel + " desc" :
            state.SortLabel;

            var pagingResponse = await _httpRequestHandler.GetPagedData(_pagingParameters, "ProductHandlers/GetPagedProducts");
            return new TableData<ProductDto>
            {
                Items = pagingResponse.Items,
                TotalItems = pagingResponse.MetaData.TotalCount
            };
        }
        private void OnSearch(string searchTerm)
        {
            _pagingParameters.SearchTerm = searchTerm;
            _table.ReloadServerData();
        }

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
            var result = await _httpRequestHandler.PostAsHttpJsonAsync(ProductDto, "ProductHandlers/AddProduct");
            if (result)
            {
                _snackbar.Add("Product Added Seccessfully", Severity.Success);
                await _table.ReloadServerData();
            }
            else
            {
                _snackbar.Add("Operation Faild", Severity.Error);
            }
        }

        private void AssignImageUrl(string imgUrl) => ProductDto.ImageUrl = imgUrl;

        private async Task DeleteProduct(int id)
        {

            var parameters = new DialogParameters
        {
            { "Content", "Are You Sure Wanna Delete This Product?" },
            { "ButtonColor", Color.Warning },
            { "ButtonText", "Delete Product" }
        };
            var dialog = _dialogService.Show<DialogNotification>("Delete Product Warning", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await _httpRequestHandler.DeleteById(id, "ProductHandlers/RemoveProduct");
                _snackbar.Add("Product Deleted Successfully", Severity.Success);
                await _table.ReloadServerData();
            }
            else
            {
                _snackbar.Add("Deleted Canceled", Severity.Info);
            }
        }
        private async Task EditProduct(int id)
        {
            NavigationManager.NavigateTo($"/updateProduct/{id}");
        }
    }
}
