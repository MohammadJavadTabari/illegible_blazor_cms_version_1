using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;

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
        public IEnumerable<MudColor> Palette4 { get; set; } = new MudColor[] { "#F44336", "#E91E63", "#9C27B0", "#673AB7", "#3F51B5" };
        
        
        [Parameter]
        public EventCallback<bool> ChangeRtlToLtr { get; set; }
        public string RTLICon = "fas fa-angle-double-right";
        public bool _rtl { get; set; } = false;
        public string? rtlOrtlrToolTip { get; set; } = "RTL Page";
        async void ChangeRTL()
        {
            _rtl = !_rtl;
            if (_rtl)
            {
                RTLICon = "fas fa-angle-double-left";
                rtlOrtlrToolTip = "LTR Page";
            }
            else
            {
                RTLICon = "fas fa-angle-double-right";
                rtlOrtlrToolTip = "RTL Page";
            }
            await ChangeRtlToLtr.InvokeAsync(_rtl);
        }
    }
}
