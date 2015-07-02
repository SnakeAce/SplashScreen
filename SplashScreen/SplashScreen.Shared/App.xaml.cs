using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Шаблон пустого приложения задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234227

namespace SplashScreen
{
    /// <summary>
    /// Обеспечивает зависящее от конкретного приложения поведение, дополняющее класс Application по умолчанию.
    /// </summary>
    public sealed partial class App : Application
    {
#if WINDOWS_PHONE_APP
        private TransitionCollection transitions;
#endif

        /// <summary>
        /// Инициализирует одноэлементный объект приложения. Это первая выполняемая строка разрабатываемого
        /// кода; поэтому она является логическим эквивалентом main() или WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Вызывается при обычном запуске приложения пользователем.  Будут использоваться другие точки входа,
        /// если приложение запускается для открытия конкретного файла, отображения
        /// результатов поиска и т. д.
        /// </summary>
        /// <param name="e">Сведения о запросе и обработке запуска.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Activate(args);
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            Activate(args);
        }

        protected override void OnSearchActivated(SearchActivatedEventArgs args)
        {
            Activate(args);
        }

        void Activate(IActivatedEventArgs args)
        {
            Action _Navigate = null;
            switch (args.Kind)
            {
                //case ActivationKind.AppointmentsProvider:
                //    break;
                //case ActivationKind.CachedFileUpdater:
                //    break;
                //case ActivationKind.CameraSettings:
                //    break;
                //case ActivationKind.Contact:
                //    break;
                //case ActivationKind.ContactPicker:
                //    break;
                //case ActivationKind.Device:
                //    break;
                //case ActivationKind.File:
                //    break;
                //case ActivationKind.FileOpenPicker:
                //    break;
                //case ActivationKind.FileSavePicker:
                //    break;
                //case ActivationKind.ShareTarget:
                //    break;
                //case ActivationKind.LockScreenCall:
                //    break;
                //case ActivationKind.PrintTaskSettings:
                //    break;
                //case ActivationKind.RestrictedLaunch:
                //    break;
                case ActivationKind.Launch:
                    {
                        //clicked a tile
                        var _Args = args as ILaunchActivatedEventArgs;
                        if (_Args.TileId.Equals("App"))
                        {
                            //primary tile
                            _Navigate = () => Services.Navigation.GotoMainPage();
                        }
                        else
                        {

                            //secondary tile
                            _Navigate = () => Services.Navigation.GotoDetail(_Args.Arguments);
                        }
                        break;
                    }
                case ActivationKind.Protocol:
                    {
                        var _Args = args as IProtocolActivatedEventArgs;
                        _Navigate = () => Services.Navigation.GotoDetail(_Args.Uri.Query);

                        break;
                    }
                case ActivationKind.Search:
                    {
                        var _Args = args as ISearchActivatedEventArgs;
                        _Navigate = () => Services.Navigation.GotoSearch(_Args.QueryText);
                        break;
                    }
                default:
                    break;
            }
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                _Navigate.Invoke();
            }
            else
            {
                var _Splash = new Views.Splash(args.SplashScreen, _Navigate);
                Window.Current.Content = _Splash;
                _Splash.Loaded += (s, e) => Window.Current.Activate();
            }
        }

        /// <summary>
        /// Вызывается при приостановке выполнения приложения.  Состояние приложения сохраняется
        /// без учета информации о том, будет ли оно завершено или возобновлено с неизменным
        /// содержимым памяти.
        /// </summary>
        /// <param name="sender">Источник запроса приостановки.</param>
        /// <param name="e">Сведения о запросе приостановки.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Сохранить состояние приложения и остановить все фоновые операции
            deferral.Complete();
        }
    }
}