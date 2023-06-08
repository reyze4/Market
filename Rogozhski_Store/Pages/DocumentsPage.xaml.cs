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
using Rogozhski_Store.Components;
using Rogozhski_Store.Components.Model;

namespace Rogozhski_Store.Pages
{
    /// <summary>
    /// Логика взаимодействия для DocumentsPage.xaml
    /// </summary>
    public partial class DocumentsPage : Page
    {
        public DocumentsPage()
        {
            InitializeComponent();
            DocumentsLV.ItemsSource = App.DB.DocumentsClient.Where(x => x.Client.RoleID == 2).ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditAddDocsPage(new DocumentsClient()));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void DocumentsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selDocument = (sender as Button).DataContext as DocumentsClient;
            NavigationService.Navigate(new EditAddDocsPage(selDocument));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selDocument = (sender as Button).DataContext as DocumentsClient;
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.DB.DocumentsClient.Remove(selDocument);
                App.DB.SaveChanges();
                Refresh();
            }
        }

        private void Refresh()
        {

            IEnumerable<DocumentsClient> filterDocument = App.DB.DocumentsClient.ToList();
                if (SearchTb.Text.Length > 0)
                {
                    filterDocument = filterDocument.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()));
                }
            DocumentsLV.ItemsSource = filterDocument.ToList();
        }
    }
}
