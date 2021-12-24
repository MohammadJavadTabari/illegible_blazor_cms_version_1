using illShop.Shared.Dto.DtosRelatedIdentity;
using MudBlazor;

namespace illShop.Client.Pages.Auth
{
    public partial class Registration
    {
        private UserForRegistrationDto _userForRegistration = new UserForRegistrationDto();
       
        public bool ShowRegistrationErrors { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public async Task Register()
        {
            ShowRegistrationErrors = false;
            var result = await _authenticationService.RegisterUser(_userForRegistration);
            if (!result.IsSuccessfulRegistration)
            {
                _snackbar.Add("Registration Error! Please Fill Inputs Correctly", Severity.Error);
            }
            else
            {
                _snackbar.Add("Wellcome, you are navigating to home page", Severity.Success);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
