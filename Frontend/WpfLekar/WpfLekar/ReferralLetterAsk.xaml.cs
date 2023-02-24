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
    /// Interaction logic for ReferralLetterAsk.xaml
    /// </summary>
    public partial class ReferralLetterAsk : Page
    {
        public ReferralLetterAsk()
        {
            InitializeComponent();
        }



        public void clkLogo(object sender, RoutedEventArgs e)
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
            NavigationService.Navigate(new Uri("/ReferralLetter.xaml", UriKind.Relative));
        }

        private void clkYes(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ExaminationOrOperation.xaml", UriKind.Relative));
        }

        private void clkNo(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PatientCard.xaml", UriKind.Relative));
            MessageBox.Show("Uspešno ste izdali uput!");
        }


    }
}
