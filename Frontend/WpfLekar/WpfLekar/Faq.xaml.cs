using System.Windows.Controls;
using System.Collections.ObjectModel;
using WpfLekar.Modeli;
using System.Windows;
using System;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for Česta_pitanja.xaml
    /// </summary>
    public partial class Faq : Page
    {

        public ObservableCollection<Questions> Ques
        {
            get;
            set;
        }


        public Faq()
        {
            InitializeComponent();
            textBox.IsEnabled = false;
            this.DataContext = this;
            Ques = new ObservableCollection<Questions>();
            Ques.Add(new Questions { Pitanje = "Da li vršite specijalističke preglede?", Odgovor = "Klinika Zdravo vrši sve specijalističke preglede kao što su: pregled interniste, kardiolog, urolog, pedijatar, dermatolog, endokrinolog, hirurg, nefrolog, reumatolog, kardio vaskularni pregled..." });
            Ques.Add(new Questions { Pitanje = "Koji je način plaćanja lekarskih pregleda?", Odgovor = "Klinika Zdravo omogućava plaćanje u gotovini ili karticom." });
            Ques.Add(new Questions { Pitanje = "Da li imate laboratoriju?", Odgovor = "Klinika Zdravo ima sve što Vam je potrebno." });
        }

        public void clkLogo(object sender, RoutedEventArgs e) {
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

        private void clkLogIn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/LogIn.xaml", UriKind.Relative));
        }





    }
}
