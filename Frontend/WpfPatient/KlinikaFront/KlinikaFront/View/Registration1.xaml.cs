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

namespace KlinikaFront.View
{
    /// <summary>
    /// Interaction logic for Registration1.xaml
    /// </summary>
    public partial class Registration1 : UserControl
    {
        public Registration1()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).RepeatedPassword = ((PasswordBox)sender).Password;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((PasswordBox)sender).Password.Length < 8)
            {
                Console.WriteLine("Kratka sifra");
            }
        }

        private void PasswordBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (!((PasswordBox)sender).Password.Equals(Password.Password))
            {
                Console.WriteLine("Ne poklapaju se");
            }
        }
    }
}
