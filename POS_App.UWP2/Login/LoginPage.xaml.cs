using POS.Services.Containers;
using POS.Services.Interfaces;
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
using Microsoft.Extensions.DependencyInjection;
using POS.ViewModels.Login;
using POS_App.UWP2;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace POS_APP.UWP.Views.Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        IUserService userService { get; set; }
        LoginVM loginVM { get; set; }
        public LoginPage()
        {
            this.InitializeComponent();
            userService = Factory.Container.GetService<IUserService>();
            loginVM = new LoginVM();
        }

        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //UserNamesCmbx.ItemsSource = userService.GetUserNames();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void PasswordTxtbx_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            //if(e.Key == Windows.System.VirtualKey.Enter)
            //    Login();
        }
        private void Login()
        {
            loginVM.UserName = UserNameTxtbx.Text;
            loginVM.Magic = PasswordTxtbx.Text;
            if (userService.Logon(loginVM))
            {
                (Window.Current.Content as Frame).Navigate(typeof(MainPage));
            }
        }

    }
}
