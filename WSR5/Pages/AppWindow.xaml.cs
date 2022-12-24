using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSR5.Database;
using WSR5.Pages;

namespace Pages.WSR5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
            PagesFrame.Navigate(new LoginPage());
        }

        private void ToLoginPageButton_Click(object sender, RoutedEventArgs e)
        {
            PagesFrame.Navigate(new LoginPage());
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (PagesFrame.CanGoBack)
                PagesFrame.GoBack();
        }
    }
}
