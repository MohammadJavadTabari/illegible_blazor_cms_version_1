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
            new MudTheme()
        };
        public MudTheme SelectTheme(string themeId)
        {
            return mudThemes[short.Parse(themeId)];
        }
    }
}
