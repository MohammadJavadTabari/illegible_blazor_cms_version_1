using MudBlazor;

namespace illShop.Client.Shared
{
    public partial class MainLayout
    {
        private bool _isLightMode = true;
        private MudTheme _currentTheme = new MudTheme();
        private void ToggleTheme()
        {
            _isLightMode = !_isLightMode;
            if (!_isLightMode)
            {
                _currentTheme = GenerateDarkTheme();
            }
            else
            {
                _currentTheme = new MudTheme();
            }
        }
        private MudTheme GenerateDarkTheme() =>
            new MudTheme
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
                    AppbarText = "#ffffffb3"
                }
            };
    }
}
