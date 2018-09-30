using POS.Services.Containers;
using POS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace POS_APP.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Factory.CreateBuilder();
            var appInitService = Factory.Container.GetService<IInitAppService>();
            appInitService.InitApp();
        }
    }
}
