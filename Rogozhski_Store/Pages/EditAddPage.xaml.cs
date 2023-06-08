using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditAddPage.xaml
    /// </summary>
    public partial class EditAddPage : Page
    {
        Client contextClient;
        public EditAddPage(Client client)
        {
            InitializeComponent();
            contextClient = client;
            DataContext = contextClient;
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (contextClient.ID == 0)
            {
                App.DB.Client.Add(contextClient);
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                App.DB.SaveChanges();
                NavigationService.GoBack();

            }
        }

        private void EditImgBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextClient.PhotoPath = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextClient;
                App.DB.SaveChanges();
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-zА-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBox_PreviewTextInput_3(object sender, TextCompositionEventArgs e)
        {
            bool result = ValidatorExtensions.IsValidEmailAddress(EmalTb.Text);
        }

        private void TextBox_PreviewTextInput_4(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
