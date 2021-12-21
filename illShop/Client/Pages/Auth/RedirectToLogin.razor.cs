namespace illShop.Client.Pages.Auth
{
    public partial class RedirectToLogin
    {
        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo($"authentication/login?returnUrl={Uri.EscapeDataString(NavigationManager.Uri)}");
        }
    }
}
