using AppMusic.Entities;
using AppMusic.Services;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppMusic.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : Page
    {
        private AccountService accountService = new AccountService();
        public ProfilePage()
        {
            this.InitializeComponent();
            Loaded += LoadProfile;
        }
        private async void LoadProfile(object sender, RoutedEventArgs e)
        {
            Account account = await accountService.GetProfile(LoginPage.AccessToken);
            firstName.Text = account.firstName;
            lastName.Text = account.lastName;
            email.Text = account.email;
            address.Text = account.address;
            phone.Text = account.phone;
            avatar.Source = new BitmapImage(new Uri(account.avatar));
            gender.Text = account.GetGenderAsString();
            birthday.Text = account.birthday;
            introduction.Text = account.introduction;
            createdTime.Text = account.created_at;
            status.Text = account.GetStaticAsString();
        }
    }
}
