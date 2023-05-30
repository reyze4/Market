using Rogozhski_Store.Components.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Rogozhski_Store
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RogozhEn DB = new RogozhEn();
        public static Client LoggedClient;
    }
}
