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

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for ChatWithColleagues.xaml
    /// </summary>
    public partial class ChatWithColleagues : Page
    {
        public ChatWithColleagues()
        {
            InitializeComponent();

        }


        private void comboDoctors(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Lenka Lenkić");
            data.Add("Filip Filipović");
            data.Add("Spasa Spasić");
            data.Add("Milan Milanović");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        static List<string> chatList = new List<string>();

        private void clkLogo(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        public void clkHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void clkService(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Service.xaml", UriKind.Relative));
        }

        private void clkFaq(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Faq.xaml", UriKind.Relative));
        }

        private void clkGallery(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Gallery.xaml", UriKind.Relative));
        }

        private void clkAboutUs(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutUs.xaml", UriKind.Relative));
        }

        private void clkContact(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Contact.xaml", UriKind.Relative));
        }

        private void clkHelp(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }


        private void clkLogOut(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void clkBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyAccount.xaml", UriKind.Relative));
        }

        private void clkSubmit(object sender, RoutedEventArgs e)
        {
            
            listBox.Items.Clear();

            chatList.Add(txtMessage.Text);
            foreach (string item in chatList)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = item;

                listBox.Items.Add(itm);
            }
            txtMessage.Clear();




        }



    }
}
