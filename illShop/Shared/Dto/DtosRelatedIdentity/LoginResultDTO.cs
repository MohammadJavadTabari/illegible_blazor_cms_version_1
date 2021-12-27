
namespace illShop.Shared.Dto.DtosRelatedIdentity
{
    public class LoginResultDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }

    }
}
