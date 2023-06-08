using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Client.Components.Model;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Rogozh_StoreEntities DB = new Rogozh_StoreEntities();
        public static Components.Model.Client LoggedClient;
    }
}
