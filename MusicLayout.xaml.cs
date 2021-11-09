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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppMusic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MusicLayout : Page
    {
        public MusicLayout()
        {
            this.InitializeComponent();
        }
        private void MyNavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            MyNavView.IsBackEnabled = true;
            MyNavView.IsBackButtonVisible = NavigationViewBackButtonVisible.Visible;
            if (args.IsSettingsInvoked)
            {
                //Xử lý khi click nut setting
                ContentPage.Navigate(typeof(Pages.SettingPage), args.RecommendedNavigationTransitionInfo);
                return;
            }

            var tag = args.InvokedItemContainer.Tag.ToString();
            switch (tag)
            {
                case "home":
                    ContentPage.Navigate(typeof(Pages.DashboardPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "createSong":
                    ContentPage.Navigate(typeof(Pages.CreateSongPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "listSong":
                    ContentPage.Navigate(typeof(Pages.ListSongPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "login":
                    ContentPage.Navigate(typeof(Pages.LoginPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "register":
                    ContentPage.Navigate(typeof(Pages.RegisterPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "profilePage":
                    ContentPage.Navigate(typeof(Pages.ProfilePage), args.RecommendedNavigationTransitionInfo);
                    break;
            }
        }

        private void MyNavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentPage.CanGoBack)
            {
                ContentPage.GoBack();
            }
        }
    }
}
