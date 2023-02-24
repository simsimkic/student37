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
using System.Collections.ObjectModel;
using WpfLekar.Modeli;
using Controller.Users;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for SchedulePatientExamination.xaml
    /// </summary>
    public partial class SchedulePatientExamination : Page
    {
        private readonly DoctorController _doctorController;
        public static List<string> doctorCombo;

        public ObservableCollection<Doctors> Doc
        {
            get;
            set;
        }

        public SchedulePatientExamination()
        {
            InitializeComponent();
            this.DataContext = this;
            doctorCombo = new List<string>();

            var app = (App)Application.Current;
            _doctorController = app.doctorController;


            List<Model.Doctor.Doctor> doctors = _doctorController.GetAllDoctors();
            foreach (Model.Doctor.Doctor doc in doctors) {
                var user = _doctorController.GetDoctor(doc.Jmbg);
                doc.LastName = user.LastName;
                doctorCombo.Add(doc.LastName);
            }



            Doc = new ObservableCollection<Doctors>();
            Doc.Add(new Doctors { Termini = "10:00", Lekari = "Filip Filipović", Sobesale = "202" });
            Doc.Add(new Doctors { Termini = "10:20", Lekari = "Filip Filipović", Sobesale = "202" });
            Doc.Add(new Doctors { Termini = "14:00", Lekari = "Filip Filipović", Sobesale = "202" });
        }

        private void comboDoctors(object sender, RoutedEventArgs e)
        {
            //data.Add("Lenka Lenkić");
            //data.Add("Filip Filipović");
            //data.Add("Spasa Spasić");
            //data.Add("Milan Milanović");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = doctorCombo;
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
            NavigationService.Navigate(new Uri("/PatientCard.xaml", UriKind.Relative));
        }

        private void clkSave(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PatientCard.xaml", UriKind.Relative));
            MessageBox.Show("Uspešno ste izdali uput i zakazali pregled!");
        }



    }
}
