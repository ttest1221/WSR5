using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WSR5.Classes;

namespace WSR5.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        bool CaptchaActive = false;
        ManagerAndUserPage userPage = new ManagerAndUserPage();
        AdminPage adminPage = new AdminPage();
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            bool IsEntered = false;
            try
            {
                if(CaptchaActive == true & CaptchaTextBox.Text != "A9C4") 
                {
                    MessageBox.Show("Капча введена неверно, система заблокирована на 10 секунд");
                    Thread.Sleep(10000);
                }
                else
                {
                    for (int i = 0; i < Users.users.Count; i++)
                    {
                        if (Users.users[i].UserLogin == LoginTextBox.Text && Users.users[i].UserPassword == UserPasswordBox.Password)
                        {
                            IsEntered = true;
                            CaptchaImage.Visibility = Visibility.Hidden;
                            CaptchaTextBlock.Visibility = Visibility.Hidden;
                            CaptchaTextBox.Visibility = Visibility.Hidden;
                            if(Users.users[i].UserRole == 1)
                            {
                                adminPage.UserFioTextBlock.Text = Users.users[i].UserSurname + " " + Users.users[i].UserName + " " + Users.users[i].UserPatronymic;
                                NavigationService.Navigate(adminPage);
                            }

                            else
                            {
                                userPage.UserFioTextBlock.Text = Users.users[i].UserSurname + " " + Users.users[i].UserName + " " + Users.users[i].UserPatronymic;
                                NavigationService.Navigate(userPage);
                            }
                                        
                        }
                    }
                    if (IsEntered == false)
                    {
                        MessageBox.Show("Неудалось успешно авторизоваться, введите капчу");
                        CaptchaImage.Visibility = Visibility.Visible;
                        CaptchaTextBlock.Visibility = Visibility.Visible;
                        CaptchaTextBox.Visibility = Visibility.Visible;
                        CaptchaActive = true;
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnterAsGuest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                userPage.UserFioTextBlock.Text = "Гость";
                NavigationService.Navigate(userPage);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
