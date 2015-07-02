using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SplashScreen.Common
{
    public class BackButton: Button
    {
        public BackButton()
        {
            this.DefaultStyleKey = typeof(Button);
            Click += BackButton_Click;
        } 

        void BackButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Services.Navigation.GoBack();
        }
    }
}
