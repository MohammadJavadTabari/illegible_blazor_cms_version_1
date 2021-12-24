using MudBlazor;

namespace illShop.Client.Shared
{
    public partial class MainLayout
    {
        private MudTheme _currentTheme = new MudTheme();
        private bool _sidebarOpen = true;
        private void ToggleTheme(MudTheme changedTheme) => _currentTheme = changedTheme;
        private void ToggleSidebar() => _sidebarOpen = !_sidebarOpen;
    }
}
