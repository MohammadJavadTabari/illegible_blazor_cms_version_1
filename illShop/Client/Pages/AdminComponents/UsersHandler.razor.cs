using illShop.Shared.Dto.DtosRelatedProduct;

namespace illShop.Client.Pages.AdminComponents
{
    public partial class UsersHandler
    {
        //private MudTable<ProductDto>? _table = new();
        //private PagingParameters _pagingParameters = new();
        //private readonly int[] _pageSizeOption = { 4, 6, 10 };
        //private async Task<TableData<ProductDto>> GetServerData(TableState state)
        //{
        //    _pagingParameters.PageSize = state.PageSize;
        //    _pagingParameters.PageNumber = state.Page + 1;
        //    state.SortDirection = SortDirection.Descending;
        //    _pagingParameters.OrderBy = state.SortDirection == SortDirection.Descending ?
        //    state.SortLabel + " desc" :
        //    state.SortLabel;

        //    var pagingResponse = await _httpRequestHandler.GetPagedData(_pagingParameters, "ProductHandlers/GetPagedProducts");
        //    return new TableData<ProductDto>
        //    {
        //        Items = pagingResponse.Items,
        //        TotalItems = pagingResponse.MetaData.TotalCount
        //    };
        //}
        //private void OnSearch(string searchTerm)
        //{
        //    _pagingParameters.SearchTerm = searchTerm;
        //    _table.ReloadServerData();
        //}
        protected override async Task OnInitializedAsync()
        {
            var aa = _httpRequestHandler.GetListData<ProductDto>("AccountHandelMethods/GetAllSiteUsers");
        }
    }
}
