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
using Rogozhski_Store.Components.Model;


namespace Rogozhski_Store.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
            ServiceLV.ItemsSource = App.DB.Client.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignUpServiceBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DiscountCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ServiceLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ServiceLV_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DiscountCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
