namespace illShop.Client.Pages.Auth
{
    public partial class LogOut
    {
        protected override async Task OnInitializedAsync()
        {
            await _authenticationService.Logout();
            NavigationManager.NavigateTo("/");
        }
    }
}
