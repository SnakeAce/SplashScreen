using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace SplashScreen.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Detail : Page
    {
      
        public Detail()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Parameter = e.Parameter.ToString();
            ParamTextBlock.Text = String.Format(ParamTextBlock.Text, e.Parameter);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var _Tile = new Windows.UI.StartScreen.SecondaryTile();
            _Tile.Arguments = this.Parameter;
            _Tile.TileId = this.Parameter;
         // old  _Tile.ShortName = string.Format("ShortName {0}",this.Parameter);
            _Tile.DisplayName = string.Format("DisplayName {0}", this.Parameter);
         // new   _Tile.VisualElements.
            //_Tile.Logo = new Uri("ms-appx:///assets/logo.png");
            //_Tile.SmallLogo = new Uri("ms-appx:///assets/SmallLogo.png");
            //_Tile.WideLogo = new Uri("ms-appx:///assets/logo.png");
            //_Tile.ForegroundText = Windows.UI.StartScreen.ForegroundText.Light;
            //_Tile.BackgroundColor = Windows.UI.Colors.DarkGreen;
            //_Tile.TileOptions = Windows.UI.StartScreen.TileOptions.ShowNameOnLogo;
            await _Tile.RequestCreateAsync();
        }

        public string Parameter { get; set; }
    }
}
