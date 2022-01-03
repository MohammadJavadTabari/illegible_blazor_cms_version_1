using MudBlazor;

namespace illShop.Client.Shared.ExtensionServices
{
    public interface IThemeCustomazition
    {
        MudTheme SelectTheme(string themeId);
    }
    public class ThemeCustomazition : IThemeCustomazition
    {
        private readonly List<MudTheme> mudThemes = new()
        {
            // dark
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
                    AppbarText = "#ffffffb3",
                    DrawerBackground = "#27272f",
                    DrawerText = "#ffffffb3",
                    DrawerIcon = "#ffffffb3"
                }
            },
            // light
            new MudTheme(),
            // pink
            new MudTheme
            {
                Palette = new Palette()
                {
                    Background = "#cf2929",
                    Surface = "#991143",
                    AppbarBackground = "#f08b81",
                    DrawerBackground = "#f08b81",
                }
            },
            // new
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Background = "#00b83a",
                    BackgroundGrey = "#272c34ff",
                    Surface = "#00995e",
                    AppbarBackground = "#00995e",
                    DrawerBackground = "#ffffffff",
                    DrawerText = "#424242ff",
                    DrawerIcon = "#616161ff"
                }
            }
        };
        public MudTheme SelectTheme(string themeId)
        {
            return mudThemes[short.Parse(themeId)];
        }
    }
}
