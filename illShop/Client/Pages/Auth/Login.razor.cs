using illShop.Shared.Dto.DtosRelatedIdentity;
using MudBlazor;

namespace illShop.Client.Pages.Auth
{
    public partial class Login
    {
        private LoginModelDto loginModelDto = new LoginModelDto();
     
        public bool ShowAuthError { get; set; }
        public string? Error { get; set; }
        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            var result = await _authenticationService.Login(loginModelDto);
            if (!result.IsAuthSuccessful)
            {
                _snackbar.Add("Authentication Error! Please Fill Inputs Correctly", Severity.Error);
            }
            else
            {
                _snackbar.Add("Wellcome, you are navigating to home page", Severity.Success);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
