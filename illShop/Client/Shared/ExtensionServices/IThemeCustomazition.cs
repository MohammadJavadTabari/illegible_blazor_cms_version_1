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
            // 0
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

            // 1
            // light
            new MudTheme(),

            // 2
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

            // 3
            // green
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
            },

            ///////////////////////////////////////
            
            // 4
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Background = "#F44336",
                    BackgroundGrey = "#E91E63",
                    Surface = "#00995e",
                    AppbarBackground = "#673AB7",
                    DrawerBackground = "#3F51B5",
                    DrawerText = "#E8EAF6",
                    DrawerIcon = "#616161ff"
                }
            },

            // 5
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Background = "#FFEBEE",
                    BackgroundGrey = "#FCE4EC",
                    Surface = "#FCE4EC",
                    AppbarBackground = "#F3E5F5",
                    DrawerBackground = "#F3E5F5",
                    DrawerText = "#EDE7F6",
                    DrawerIcon = "#E8EAF6"
                }
            },

            // 6
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Background = "#FFCDD2",
                    BackgroundGrey = "#F8BBD0",
                    Surface = "#E1BEE7",
                    AppbarBackground = "#D1C4E9",
                    DrawerBackground = "#D1C4E9",
                    DrawerText = "#C5CAE9",
                    DrawerIcon = "#E8EAF6"
                }
            },

            // 7
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Background = "#EF9A9A",
                    BackgroundGrey = "#EF9A9A",
                    Surface = "#F48FB1",
                    AppbarBackground = "#CE93D8",
                    DrawerBackground = "#CE93D8",
                    DrawerText = "#B39DDB",
                    DrawerIcon = "#9FA8DA"
                }
            },

            // 8
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Background = "#E57373",
                    BackgroundGrey = "#E57373",
                    Surface = "#F06292",
                    AppbarBackground = "#BA68C8",
                    DrawerBackground = "#BA68C8",
                    DrawerText = "#9575CD",
                    DrawerIcon = "#7986CB"
                }
            },

            // 9
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Background = "#EF5350",
                    BackgroundGrey = "#EF5350",
                    Surface = "#EC407A",
                    AppbarBackground = "#AB47BC",
                    DrawerBackground = "#AB47BC",
                    DrawerText = "#7E57C2",
                    DrawerIcon = "#5C6BC0"
                }
            },

            // 10
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Background = "#E53935",
                    BackgroundGrey = "#E53935",
                    Surface = "#D81B60",
                    AppbarBackground = "#8E24AA",
                    DrawerBackground = "#8E24AA",
                    DrawerText = "#5E35B1",
                    DrawerIcon = "#3949AB"
                }
            },

            // 11
            new MudTheme
            {
                Palette = new Palette()
                {
                    Black = "#27272f",
                    Background = "#c7c8d4",
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
            }
    };
        public MudTheme SelectTheme(string themeId)
        {
            return mudThemes[short.Parse(themeId)];
        }
    }
}
