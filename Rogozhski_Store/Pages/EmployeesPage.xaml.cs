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
            Refresh();
            ServiceLV.ItemsSource = App.DB.Client.Where(X => X.RoleID == 2).ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditAddPage(new Client()));
            Refresh();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selClient = (sender as Button).DataContext as Client;
            NavigationService.Navigate(new EditAddPage(selClient));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selClient = (sender as Button).DataContext as Service;
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.DB.Service.Remove(selClient);
                App.DB.SaveChanges();
                Refresh();
            }
        }

        private void ServiceLV_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {

            IEnumerable<Client> filterClient = App.DB.Client.ToList();
            if (SortCb.SelectedIndex == 1)
                filterClient = filterClient.OrderBy(x => x.GenderCode);
            else if (SortCb.SelectedIndex == 2)
                filterClient = filterClient.OrderByDescending(x => x.GenderCode);
            if (DiscountCb.SelectedIndex > 0)
                
            if (SearchTb.Text.Length > 0)
            {
                filterClient = filterClient.Where(x => x. LastName.ToLower().StartsWith(SearchTb.Text.ToLower()));
            }
            ServiceLV.ItemsSource = filterClient.ToList();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DocsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DocumentsPage());
        }
    }
}
