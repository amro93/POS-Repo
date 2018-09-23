using Autofac;
using POS.DAL.Interfaces;
using POS.DAL.Models;
using POS.Services;
using POS.Services.Containers;
using POS.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace POS_APP.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public LoginVM ViewModel { get; }
        public MainPage()
        {
            this.InitializeComponent();
            //ViewModel = (Application.Current as App).Container.GetService(typeof(LoginVM)) as LoginVM;
            //modelConverter = (IModelConverter<User, LoginVM>)(Application.Current as App).Container.GetService(typeof(IModelConverter<User, LoginVM>));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //clientsService.GetAllClients();
        }
    }
}
