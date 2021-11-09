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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppMusic.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        private AccountService accountService = new AccountService();
        private int choosedGender = 1;
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var account = new Account
            {
                firstName = txtFirstName.Text,
                lastName = txtLastName.Text,
                password = txtPassword.Password.ToString(),
                address = txtAddress.Text,
                phone = txtPhone.Text,
                avatar = txtAvt.Text,
                gender = choosedGender,
                email = txtEmail.Text,
                birthday = datePickerBirthday.SelectedDate.Value.ToString("yyyy-MM-dd"),
                introduction = txtIntroduction.Text
            };
            var result = await accountService.Register(account);
            if (result)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Account success";
                dialog.Content = $"Create account success!";
                dialog.PrimaryButtonText = "OK";
                await dialog.ShowAsync();
                Frame.Navigate(typeof(Pages.ListSongPage));
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            switch (radioButton.Tag)
            {
                case "Male":
                    choosedGender = 1;
                    break;
                case "Female":
                    choosedGender = 1;
                    break;
                case "Other":
                    choosedGender = 2;
                    break;
            }
        }
    }
}
