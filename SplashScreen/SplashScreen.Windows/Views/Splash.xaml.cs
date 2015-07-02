using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Search;
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
    public sealed partial class Splash : Page
    {
        public Splash(Windows.ApplicationModel.Activation.SplashScreen splashScreen, Action navigate)
        {
            this.InitializeComponent();
            Loaded += async (s, e) =>
                {
                    //load data 
                    await Task.Delay(2000);
                    navigate.Invoke();
                };
            //setup search (if you don't use the search contract)
            //searchpane.getforcurrentview()
            //    .querysubmitted += (s, e) => services.navigation.gotosearch(e.querytext);

            //setup size
            Resize(splashScreen);
            Window.Current.SizeChanged += (s, e) => Resize(splashScreen);

        }

        private void Resize(Windows.ApplicationModel.Activation.SplashScreen splashScreen)
        {
            MyImage.Height = splashScreen.ImageLocation.Height;
            MyImage.Width = splashScreen.ImageLocation.Width;
            MyImage.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
            MyImage.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
        }
    }
}
