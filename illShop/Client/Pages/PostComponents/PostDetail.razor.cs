using illShop.Shared.Dto.DtosRelatedBlog;
using Microsoft.AspNetCore.Components;

namespace illShop.Client.Pages.PostComponents
{
    public partial class PostDetail
    {
        [Parameter]
        public int Id { get; set; }
        private readonly BlogPostDto blogPostDto = new();
    }
}
