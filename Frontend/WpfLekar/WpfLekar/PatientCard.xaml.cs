
using Model.Patient;
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
using WpfLekar.Modeli;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for PatientCard.xaml
    /// </summary>
    public partial class PatientCard : Page
    {
        public PatientCard()
        {
            InitializeComponent();

            txtName.Text = Global.currPatient.name;
            txtLastname.Text = Global.currPatient.lastname;
            txtJMBG.Text = Global.currPatient.jmbg;
            txtContact.Text = Global.currPatient.phone;
            txtAddress.Text = Global.currPatient.address;
            txtDateOfBirth.Text = Global.currPatient.dateOfBirth;
            txtEmail.Text = Global.currPatient.email;
            txtUsername.Text = Global.currPatient.username;

            txtName.IsEnabled = false;
            txtLastname.IsEnabled = false;
            txtJMBG.IsEnabled = false;
            txtContact.IsEnabled = false;
            txtAddress.IsEnabled = false;
            txtDateOfBirth.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtUsername.IsEnabled = false;
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


        private void clkLogOut(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void clkFinish(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyAccount.xaml", UriKind.Relative));
        }

        private void clkAnamnesis(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Anamnesis.xaml", UriKind.Relative));
        }

        private void clkReports(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Reports.xaml", UriKind.Relative));
        }

        private void clkAllergies(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Allergies.xaml", UriKind.Relative));
        }

        private void clkReferral(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReferralLetter.xaml", UriKind.Relative));
        }

        private void clkSchedule(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SchedulePatientExamination.xaml", UriKind.Relative));
        }
    }
}
