using illShop.Shared.Dto.DtosRelatedIdentity;

namespace illShop.Client.Pages.Auth
{
    public partial class Login
    {
        private LoginModelDto loginModelDto = new LoginModelDto();
     
        public bool ShowAuthError { get; set; }
        public string Error { get; set; }
        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            var result = await _authenticationService.Login(loginModelDto);
            if (!result.IsAuthSuccessful)
            {
                Error = result.Error;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
