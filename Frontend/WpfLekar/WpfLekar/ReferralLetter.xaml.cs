using Controller.Documents;
using Controller.Users;
using Model.Doctor;
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
    /// Interaction logic for ReferralLetter.xaml
    /// </summary>
    public partial class ReferralLetter : Page
    {
        private readonly SpecializationController _specializationController;
        private readonly ReferralLetterController _referralLetterController;
        public static List<string> specializationCombo;

        public ReferralLetter()
        {
            InitializeComponent();
            this.DataContext = this;
            specializationCombo = new List<string>();
        
            var app = (App)Application.Current;
            _specializationController = app.specializationController;

            //TEST PODACI
            //string spec1 = "Transfuziolog";
            //string spec2 = "Hirurg";
            //string spec3 = "Oftamolog";
            //Model.Doctor.Specialization specialization = new Model.Doctor.Specialization();
            //specialization.Name = spec3;
            //specialization = _specializationController.AddSpecialization(specialization);


            var specializationCSV = _specializationController.GetAllSpecializations();
                if (specializationCSV != null)
                {
                    foreach (var spec in specializationCSV)
                    {
                        specializationCombo.Add(spec.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Nema specijalista!");
                }

        }


        private void comboSpecialist(object sender, RoutedEventArgs e)
        {
            

            //data.Add("hirurg");
            //data.Add("transfuziolog");
            //data.Add("oftamolog");

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = specializationCombo;
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
            if (!txtNote.Text.Equals("Napomena"))
            {
                string toSpecialization = cbSpec.Text.ToString();
                string note = txtNote.Text;
                var app = (App)Application.Current;
                Model.Doctor.ReferralLetter referralLetter = new Model.Doctor.ReferralLetter();
                referralLetter.Note = note;
                Specialization specialization = app.specializationController.GetSpecializationByName(toSpecialization);
                referralLetter.MedicalExamination = new MedicalExamination() { Id = 0 };
                referralLetter.MedicalOperation = new Model.Secretary.MedicalOperation(0);
                referralLetter.Specialization = specialization;
                app.referralLetterController.AddReferralLetter(referralLetter);

                NavigationService.Navigate(new Uri("/ReferralLetterAsk.xaml", UriKind.Relative));
            }
            else {
                MessageBox.Show("Niste naveli razlog izdavanja uputa!");
            }
        }


    }
}
