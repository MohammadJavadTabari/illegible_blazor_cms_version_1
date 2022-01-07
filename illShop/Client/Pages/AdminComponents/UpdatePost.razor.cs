using illShop.Shared.Dto.DtosRelatedBlog;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace illShop.Client.Pages.AdminComponents
{
    public partial class UpdatePost
    {
        [Parameter]
        public int Id { get; set; }
        public BlogPostDto BlogPostDto = new();

        protected override async Task OnInitializedAsync()
        {
            BlogPostDto = await _httpRequestHandler.GetById<BlogPostDto>(Id, "blogPostHandler/GetBlogPost");
        }

        public async Task Update()
        {
            var response = await _httpRequestHandler.UpdateByDto(BlogPostDto, "blogPostHandler/UpdateBlogPost");
            if (response)
            {
                _snackbar.Add("Post Updated Successfully", Severity.Success);
            }
            else
            {
                _snackbar.Add("Edit Faild!", Severity.Error);
            }
        }

        private void AssignImageUrl(string imgUrl) => BlogPostDto.PostImageUrl = imgUrl;
    }
}
