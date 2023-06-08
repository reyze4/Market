using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Rogozhski_Store.Components;
using Rogozhski_Store.Components.Model;

namespace Rogozhski_Store.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditAddDocsPage.xaml
    /// </summary>
    public partial class EditAddDocsPage : Page
    {
        DocumentsClient contextDocumentClient;
        public EditAddDocsPage(DocumentsClient document)
        {
            InitializeComponent();
            contextDocumentClient = document;
            DataContext = contextDocumentClient;
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (contextDocumentClient.ID == 0)
            {
                App.DB.DocumentsClient.Add(contextDocumentClient);
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                App.DB.SaveChanges();
                NavigationService.GoBack();

            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {

        }

        private void EmalTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
