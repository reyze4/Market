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

namespace Administrator.Pages
{
    /// <summary>
    /// Логика взаимодействия для CapchaPage.xaml
    /// </summary>
    public partial class CapchaPage : Page
    {
        public CapchaPage()
        {
            InitializeComponent();
        }
        private static Random rnd = new Random();
        private static int countsymbol = 6;
        private static string Capcha = "";

        public void GenerateSymbol()
        {
            string alp = "1234567890ABCDEFGHIJKLMNOPqwertyuiopasdfghjklzxcvbnm~!@#$%^&*";
            for (int i = 0; i < countsymbol; i++)
            {
                string symbol = alp.ElementAt(rnd.Next(0, alp.Length)).ToString();
                TextBlock textBlock = new TextBlock();
                textBlock.Text = symbol;
                textBlock.FontSize = rnd.Next(15, 25);
                textBlock.RenderTransform = new RotateTransform(rnd.Next(-45, 45));
                textBlock.Margin = new Thickness(10, -50, 10, 0);
                //textBlock.Foreground = new SolidColorBrush(Color.FromRgb(
                //        (byte)rnd.Next(100, 256),
                //        (byte)rnd.Next(100, 256),
                //        (byte)rnd.Next(100, 256) ));

                Stak.Children.Add(textBlock);
                Capcha += textBlock.Text;
            }

        }
        public void GenereateShum(int noise)
        {
            for (int i = 0; i < noise; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(
                        (byte)rnd.Next(100, 256),
                        (byte)rnd.Next(100, 256),
                        (byte)rnd.Next(100, 256),
                        (byte)rnd.Next(100, 256)));
                ellipse.Height = ellipse.Width = rnd.Next(20, 50);
                canvass.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rnd.Next(0, 300));
                Canvas.SetTop(ellipse, rnd.Next(0, 200));
            }
            for (int i = 0; i < noise; i++)
            {
                Rectangle ellipse = new Rectangle();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(
                        (byte)rnd.Next(100, 200),
                        (byte)rnd.Next(100, 256),
                        (byte)rnd.Next(100, 256),
                        (byte)rnd.Next(100, 256)));
                ellipse.Height = ellipse.Width = rnd.Next(20, 50);
                canvass.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rnd.Next(0, 300));
                Canvas.SetTop(ellipse, rnd.Next(0, 120));
            }
        }
        public void UpdateCapcha()
        {
            Capcha = "";
            Stak.Children.Clear();
            canvass.Children.Clear();
            GenerateSymbol();
            GenereateShum(rnd.Next(70, 250));

        }

        private void ChekBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TbCapch.Text == Capcha.Trim())
            {
                MessageBox.Show("Капча успешно пройдена");
                NavigationService.Navigate(new MenuPage());

            }
            else
            {
                MessageBox.Show("Капча введена не верно");
                TbCapch.Clear();
                UpdateCapcha();

            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            countsymbol = rnd.Next(5, 8);
            UpdateCapcha();
        }
    }
}
