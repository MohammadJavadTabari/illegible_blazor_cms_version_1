using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace illShop.Client.Shared.Helpers
{
    [Authorize(Roles = "Administrator")]
    public partial class ImageUpload
    {
        [Parameter]
        public string ImgUrl { get; set; }
        [Parameter]
        public EventCallback<string> OnChange { get; set; }

        private async Task UploadImage(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles();
            foreach (var imageFile in imageFiles)
            {
                if (imageFile != null)
                {
                    var resizedFile = await imageFile.RequestImageFileAsync("image/png", 300, 500);
                    using (var ms = resizedFile.OpenReadStream(resizedFile.Size))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(resizedFile.Size)), "image", imageFile.Name);
                        ImgUrl = await _httpRequestHandler.UploadImage(content, "UploadStaticFileHandler/UploadStaticFile");
                        await OnChange.InvokeAsync(ImgUrl);
                    }
                }
            }
        }
    }
}