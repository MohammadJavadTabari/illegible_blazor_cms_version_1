using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace illShop.Client.Shared
{
    public partial class AppBar
    {
        private MudTheme _currentTheme = new();
        [Parameter]
        public EventCallback OnSidebarToggled { get; set; }
        [Parameter]
        public EventCallback<MudTheme> OnThemeToggled { get; set; }
        public string ThemeId { get; set; } = "0";

        private async Task ValueChanged()
        {
            _currentTheme = _themeCustomazition.SelectTheme(ThemeId);
            await OnThemeToggled.InvokeAsync(_currentTheme);
        }
    }
}
