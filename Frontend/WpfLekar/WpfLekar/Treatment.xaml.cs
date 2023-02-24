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
using System.Collections.ObjectModel;
using Controller.Documents;
using Controller.MedicalServices;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for Treatment.xaml
    /// </summary>
    public partial class Treatment : Page
    {
        private readonly DiagnosisController _diagnosisController;
        private readonly TreatmentController _treatmentController;
        ObservableCollection<ListOfDiagnosis> selectedDiags = new ObservableCollection<ListOfDiagnosis>();

        public ObservableCollection<ListOfTreatments> treatments
        {
            get;
            set;
        }

        public ObservableCollection<ListOfDiagnosis> SelectedDiags
        {
            get { return selectedDiags; }
            set
            {
                selectedDiags = value;

            }
        }

        public ObservableCollection<ListOfDiagnosis> diags
        {
            get;
            set;
        }

        public Treatment()
        {
            InitializeComponent();
            this.DataContext = this;

            treatments = new ObservableCollection<ListOfTreatments>();

            try
            {

                var app = (App)Application.Current;
                _treatmentController = app.treatmentController;

                var treatmentCSV = _treatmentController.GetAllTreatments();
                if (treatmentCSV != null)
                {
                    foreach (var diag in treatmentCSV)
                    {
                        treatments.Add(new ListOfTreatments { Tretman = diag.Name });
                    }
                }
                else
                {
                    MessageBox.Show("Nema dijagnoza!");
                }
                
            }
            catch (Exception e)
            {
                
            }

            //treatments.Add(new ListOfTreatments { Tretman = "Ušivanje" });
            //treatments.Add(new ListOfTreatments { Tretman = "Vežbe za leđa" });
            //treatments.Add(new ListOfTreatments { Tretman = "Vežbe za povređenu ruku" });
            //treatments.Add(new ListOfTreatments { Tretman = "Tretman strujom" });

            diags = new ObservableCollection<ListOfDiagnosis>();
            //diags.Add(new ListOfDiagnosis { Dijagnoza = "Zapaljenje creva" });
            //diags.Add(new ListOfDiagnosis { Dijagnoza = "Upala pluća" });
            //diags.Add(new ListOfDiagnosis { Dijagnoza = "Trovanje" });

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

        private void clkSave(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Anamnesis.xaml", UriKind.Relative));
        }

        private void clkBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Anamnesis.xaml", UriKind.Relative));
        }

        private void clkAddTreatment(object sender, RoutedEventArgs e)
        {
            Model.Doctor.Treatment diag = new Model.Doctor.Treatment();
            diag.Name = txtAddTreatment.Text;

            diag = _treatmentController.AddTreatment(diag);         

            ListOfTreatments newDiag = new ListOfTreatments
            {
                Tretman = diag.Name
            };
            treatments.Add(newDiag);

            if (!txtAddTreatment.Text.Equals(""))
            {
                txtAddTreatment.Clear();
            }
            else
            {
                MessageBox.Show("Morate uneti dijagnozu!");
            }

        }
    }
}
