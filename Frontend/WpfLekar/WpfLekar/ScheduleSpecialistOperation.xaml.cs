using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Collections.ObjectModel;
using WpfLekar.Modeli;


namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for ScheduleSpecialistOperation.xaml
    /// </summary>
    public partial class ScheduleSpecialistOperation : Page
    {

        public ObservableCollection<Doctors> Doc
        {
            get;
            set;
        }

        public ScheduleSpecialistOperation()
        {
            InitializeComponent();
            this.DataContext = this;
            Doc = new ObservableCollection<Doctors>();
            Doc.Add(new Doctors { Termini = "10:00", Lekari = "Filip Filipović", Sobesale = "202" });
            Doc.Add(new Doctors { Termini = "10:20", Lekari = "Filip Filipović", Sobesale = "202" });
            Doc.Add(new Doctors { Termini = "14:00", Lekari = "Filip Filipović", Sobesale = "202" });
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

        private void comboRooms(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("200");
            data.Add("203");
            data.Add("207");
            data.Add("309");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }


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

        private void clkRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

        private void clkLogOut(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void clkBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReferralLetter.xaml", UriKind.Relative));
        }


        private void clkSave(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RecoveryRoomAsk.xaml", UriKind.Relative));
        }


    }
}
