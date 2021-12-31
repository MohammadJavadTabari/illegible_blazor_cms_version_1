using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedProduct;
using MudBlazor;

namespace illShop.Client.Pages.AdminComponents
{
    public partial class ProductCategory
    {

        private MudTable<ProductCategoryDto>? _table = new();
        private PagingParameters _pagingParameters = new();
        private readonly int[] _pageSizeOption = { 4, 6, 10 };
        private async Task<TableData<ProductCategoryDto>> GetServerData(TableState state)
        {
            _pagingParameters.PageSize = state.PageSize;
            _pagingParameters.PageNumber = state.Page + 1;
            state.SortDirection = SortDirection.Descending;
            _pagingParameters.OrderBy = state.SortDirection == SortDirection.Descending ?
            state.SortLabel + " desc" :
            state.SortLabel;

            var pagingResponse = await _httpRequestHandler.GetPagedProductCategory(_pagingParameters, "CategoryHandler/GetPagedProductCategories");
            return new TableData<ProductCategoryDto>
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

        public ProductCategoryDto ProductCategoryDto = new();
        public string Icon { get; set; } = "fas fa-basketball-ball";
        private async Task Create()
        {
            ProductCategoryDto.Icon = Icon;
            await _httpRequestHandler.PostAsHttpJsonAsync(ProductCategoryDto, "CategoryHandler/AddProductCategory");
            _snackbar.Add("Product Category Added Successfully",MudBlazor.Severity.Success);
        }
        List<string> iconsList = new List<string>()
        {
            "fas fa-basketball-ball",
            "fas fa-bicycle",
            "fas fa-beer",
            "fas fa-blender-phone",
            "fab fa-btc",
            "fas fa-business-time",
            "fas fa-cart-arrow-down",
            "fas fa-carrot",
            "fas fa-cocktail",
            "fab fa-android",
            "fas fa-capsules",
            "fas fa-car",
            "fas fa-bed",
            "fas fa-chalkboard",
            "fas fa-couch",
            "fas fa-tshirt",
            "fas fa-user-tie",
            "fas fa-mitten",
            "fas fa-shoe-prints",
            "fas fa-hat-cowboy"
        };
        private bool dense = false;
        private bool hover = true;
        private bool ronly = false;
        private ProductCategoryDto elementBeforeEdit;
        private ProductCategoryDto selectedItem = null;
        private void BackupItem(object element)
        {
            elementBeforeEdit = new()
            {
                Icon = ((ProductCategoryDto)element).Icon,
                CategoryName = ((ProductCategoryDto)element).CategoryName,
            };
        }
        private void ResetItemToOriginalValues(object element)
        {
            ((ProductCategoryDto)element).Icon = elementBeforeEdit.Icon;
            ((ProductCategoryDto)element).CategoryName = elementBeforeEdit.CategoryName;
        }
        private async void ItemHasBeenCommitted(object element)
        {
            var pc = new ProductCategoryDto()
            {
                Id = ((ProductCategoryDto)element).Id,
                CategoryName = ((ProductCategoryDto)element).CategoryName,
                Icon = ((ProductCategoryDto)element).Icon,
            };
            await _httpRequestHandler.UpdateByDto(pc, "CategoryHandler/UpdateCategory");
            await _table.ReloadServerData();
        }
    }
}