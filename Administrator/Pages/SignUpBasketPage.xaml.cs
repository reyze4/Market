﻿using System;
using System.Collections.Generic;
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
using Administrator.Components.Model;

namespace Administrator.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpBasketPage.xaml
    /// </summary>
    public partial class SignUpBasketPage : Page
    {
        Service contextService;
        public SignUpBasketPage(Service service)
        {
            InitializeComponent();
            ClientCb.ItemsSource = App.DB.Client.Where(x => x.RoleID == 3).ToList();
            contextService = service;
            DataContext = contextService;
            ClientCb.ItemsSource = App.DB.Client.ToList();
            DataDP.Text = DateTime.Now.ToString("t");
            DataTB.Text = DateTime.Now.ToString("t");
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-zА-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BSignUp_Click(object sender, RoutedEventArgs e)
        {

            if (ClientCb.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента!!");
                return;
            }
            var DataTime = DateTime.Parse(DataDP.Text);
            var Time = TimeSpan.Parse(DataTB.Text);
            App.DB.ClientService.Add(new ClientService
            {
                Service = contextService,
                Client = (Components.Model.Client)ClientCb.SelectedItem,
                StartTime = new DateTime(DataTime.Year, DataTime.Month, DataTime.Day, Time.Hours, Time.Minutes, 0)
            }
            );
            MessageBox.Show("Успешно");
            App.DB.SaveChanges();
            NavigationService.Navigate(new MenuPage());

        }
    }
}




