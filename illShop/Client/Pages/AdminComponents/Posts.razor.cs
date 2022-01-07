using illShop.Client.Shared.Helpers;
using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedBlog;
using MudBlazor;

namespace illShop.Client.Pages.AdminComponents
{
    public partial class Posts
    {
        private MudTable<BlogPostDto>? _table = new();
        private PagingParameters _pagingParameters = new();
        private readonly int[] _pageSizeOption = { 4, 6, 10 };
        private async Task<TableData<BlogPostDto>> GetServerData(TableState state)
        {
            _pagingParameters.PageSize = state.PageSize;
            _pagingParameters.PageNumber = state.Page + 1;
            state.SortDirection = SortDirection.Descending;
            _pagingParameters.OrderBy = state.SortDirection == SortDirection.Descending ?
            state.SortLabel + " desc" :
            state.SortLabel;

            var pagingResponse = await _httpRequestHandler.GetPagedPost(_pagingParameters, "blogPostHandler/GetPagedBlogPosts");
            return new TableData<BlogPostDto>
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

        public BlogPostDto BlogPostDto = new();
        private DateTime? _date = DateTime.Today;
        public int CategoryId { get; set; }

        private async Task Create()
        {
            var result = await _httpRequestHandler.PostAsHttpJsonAsync(BlogPostDto, "blogPostHandler/AddBlogPost");
            if (result)
            {
                _snackbar.Add("Post Added Successfully", Severity.Success);
                await _table.ReloadServerData();
            }
            else
            {
                _snackbar.Add("Operation Faild", Severity.Error);
            }
        }

        private void AssignImageUrl(string imgUrl) => BlogPostDto.PostImageUrl = imgUrl;

        private async Task DeletePost(int id)
        {

            var parameters = new DialogParameters
        {
            { "Content", "Are You Sure Wanna Delete This Post?" },
            { "ButtonColor", Color.Warning },
            { "ButtonText", "Delete Post" }
        };
            var dialog = _dialogService.Show<DialogNotification>("Delete Post Warning", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await _httpRequestHandler.DeleteById(id, "blogPostHandler/DeleteBlogPost");
                if (response)
                {
                    _snackbar.Add("Post Deleted Successfully", Severity.Success);
                    await _table.ReloadServerData();
                }
                else
                {
                    _snackbar.Add("Deleted Faild", Severity.Error);
                }

            }
            else
            {
                _snackbar.Add("Deleted Canceled", Severity.Info);
            }
        }
        private async Task EditPost(int id)
        {
            NavigationManager.NavigateTo($"/updatePost/{id}");
        }
    }
}
