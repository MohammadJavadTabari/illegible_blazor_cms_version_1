using illShop.Shared.Dto.DtosRelatedBlog;
using Microsoft.AspNetCore.Components;

namespace illShop.Client.Pages.PostComponents
{
    public partial class PostDetail
    {
        [Parameter]
        public int Id { get; set; }
        public BlogPostDto blogPostDto = new();

        protected override async Task OnInitializedAsync()
        {
            blogPostDto = await _httpRequestHandler.GetById<BlogPostDto>(Id, "blogPostHandler/GetBlogPost");
        }
    }
}
