﻿using System;
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
    /// Логика взаимодействия для EditAddPage.xaml
    /// </summary>
    public partial class EditAddPage : Page
    {
        Service contextService;
        public EditAddPage(Service service)
        {
            InitializeComponent();
            contextService = service;
            DataContext = contextService;
        }
    }
}