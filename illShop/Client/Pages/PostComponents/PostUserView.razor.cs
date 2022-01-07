using illShop.Shared.Dto.DtosRelatedBlog;

namespace illShop.Client.Pages.PostComponents
{
    public partial class PostUserView
    {
        public List<BlogPostDto> blogPostDtos = new();

        protected override async Task OnInitializedAsync()
        {
            blogPostDtos = await _httpRequestHandler.GetListData<BlogPostDto>("blogPostHandler/GetAllBlogPost");
        }
    }
}
