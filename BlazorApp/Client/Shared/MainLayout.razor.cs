using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Client.Shared
{
    public partial class MainLayout
    {
        bool _drawerOpen = true;
        bool _darkMode = false;


        MudTheme _currentTheme = new MudTheme();
        Palette _currentPalette;
        Typography _currentTypography;

        protected override void OnInitialized()
        {
            // Initialize MudTheme
            _currentPalette = _darkMode ? _currentTheme.Palette = DarkPalette : _currentTheme.Palette = LightPalette;
            _currentTypography = _currentTheme.Typography = DefaultTypography;
        }


        [Parameter]
        public EventCallback<bool> OnDrawerToggled { get; set; }
        private async Task DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;

            await OnDrawerToggled.InvokeAsync(_drawerOpen);
        }


        [Parameter]
        public EventCallback<MudTheme> OnPaletteToggled { get; set; }

        private async Task PaletteToggle()
        {
            _darkMode = !_darkMode;
            _currentPalette = _darkMode ? _currentTheme.Palette = DarkPalette : _currentTheme.Palette = LightPalette;

            await OnPaletteToggled.InvokeAsync(_currentTheme);
        }


        Palette LightPalette = new Palette()
        {
            Black = "#272c34",
            White = "#ffffff",
            Primary = "#ffffff",
            PrimaryContrastText = "#000000",
            Secondary = "#e20074",
            SecondaryContrastText = "#ffffff",

            AppbarBackground = "#e20074",
            AppbarText = "ffffff"
        };

        Palette DarkPalette = new Palette()
        {
            Black = "#ffffff",
            White = "#272c34",
            Primary = "#272c34",
            PrimaryContrastText = "#ffffff",
            Secondary = "#e20074",
            SecondaryContrastText = "#ffffff",

            Surface = "#373740",

            Dark = "#424242ff",
            DarkContrastText = "ffffffff",

            AppbarBackground = "000000",
            AppbarText = "ffffff"
        };

        Typography DefaultTypography = new Typography()
        {
            Default = new Default()
            {

            },
            Body1 = new Body1() { },
            Body2 = new Body2() { },
            Button = new Button() { },



            H1 = new H1()
            {
                FontSize = "2rem"

            },
            H2 = new H2()
            {
                FontSize = "1.5rem"

            },
            H3 = new H3()
            {
                FontSize = "1.17rem"

            },
            H4 = new H4()
            {
                FontSize = "1rem"

            },
            H5 = new H5()
            {
                FontSize = "0.83rem"

            },
            H6 = new H6()
            {
                FontSize = "0.67rem"

            }
        };
    }
}
