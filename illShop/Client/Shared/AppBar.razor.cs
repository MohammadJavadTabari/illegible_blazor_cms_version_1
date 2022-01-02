using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace illShop.Client.Shared
{
    public partial class AppBar
    {
        private bool _isDarkMode = true;
        private MudTheme _currentTheme = new MudTheme
        {
            Palette = new Palette()
            {
                Black = "#27272f",
                Background = "#32333d",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                TextPrimary = "#ffffffb3",
                TextSecondary = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#27272f",
                AppbarText = "#ffffffb3",
                DrawerBackground = "#27272f",
                DrawerText = "#ffffffb3",
                DrawerIcon = "#ffffffb3"
            }
        };
        [Parameter]
        public EventCallback OnSidebarToggled { get; set; }
        [Parameter]
        public EventCallback<MudTheme> OnThemeToggled { get; set; }
        public string ThemeId { get; set; } = "1";

        private async Task ValueChanged()
        {
            _currentTheme = _themeCustomazition.SelectTheme(ThemeId);
            await OnThemeToggled.InvokeAsync(_currentTheme);
        }
        private MudTheme GenerateLightTheme() =>
            new MudTheme();
    }
}
