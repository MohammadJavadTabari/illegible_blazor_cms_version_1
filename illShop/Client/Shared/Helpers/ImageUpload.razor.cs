using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using Tewr.Blazor.FileReader;

namespace illShop.Client.Shared.Helpers
{
    public partial class ImageUpload
    {
        private ElementReference _input;
        [Parameter]
        public string ImgUrl { get; set; }
        [Parameter]
        public EventCallback<string> OnChange { get; set; }
        [Inject]
        public IFileReaderService FileReaderService { get; set; }
      
        private async Task HandleSelected()
        {
            foreach (var file in await FileReaderService.CreateReference(_input).EnumerateFilesAsync())
            {
                if (file != null)
                {
                    var fileInfo = await file.ReadFileInfoAsync();
                    using (var ms = await file.CreateMemoryStreamAsync(4 * 1024))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(ms.Length)), "image", fileInfo.Name);
                        ImgUrl = await _httpRequestHandler.UploadImage(content, "UploadStaticFileHandler/UploadStaticFile");
                        await OnChange.InvokeAsync(ImgUrl);
                    }
                }
            }
        }
    }
}
