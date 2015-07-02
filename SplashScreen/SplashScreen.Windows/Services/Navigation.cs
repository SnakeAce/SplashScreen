using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SplashScreen.Services
{
    public static class Navigation
    {
        private static Frame Frame
        {
            get
            {
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame == null)
                {
                    rootFrame = new Frame();
                    // TODO: Измените это значение на размер кэша, подходящий для вашего приложения
                    rootFrame.CacheSize = 1;
                    //if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                    //{
                    //     TODO: Загрузить состояние из ранее приостановленного приложения
                    //}
                    Window.Current.Content = rootFrame;
                }
                return rootFrame;
            }
        }

        public static void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            } else
            {
                GotoMainPage();
            }
        }

        public static Boolean GotoMainPage()
        {
            return Frame.Navigate(typeof(MainPage));
        }

        public static Boolean GotoDetail(string arg)
        {
            return Frame.Navigate(typeof(Views.Detail), arg);
        }
        public static Boolean GotoSearch(string arg)
        {
            return Frame.Navigate(typeof(Views.Search), arg);
        }
    }

}
