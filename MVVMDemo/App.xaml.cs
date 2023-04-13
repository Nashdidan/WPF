using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //// Create a new NavigationWindow
            //NavigationWindow window = new NavigationWindow();

            //// Set the source of the NavigationWindow to the first page you want to display
            //window.Source = new Uri("MainWindow.xaml", UriKind.Relative);

            //// Show the NavigationWindow
            //window.Show();
        }
    }
}
