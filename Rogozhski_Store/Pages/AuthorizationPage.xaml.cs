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

namespace Rogozhski_Store.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var client = App.DB.Client.FirstOrDefault(emp => emp.Email == LoginTb.Text);
            if (client == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if (client.Phone != PasswordTb.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            App.LoggedClient = client;

            NavigationService.Navigate(new CaptchaPage());
        }
    }
}
