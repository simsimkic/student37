using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
using Klinika;
using Model.Doctor;
using Controller.Users;
using Controller.Documents;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for Anamnesis.xaml
    /// </summary>
    public partial class Anamnesis : Page
    {

        public bool CheckBoxes { get; set; }
        private readonly DiagnosisController _diagnosisController;
        ObservableCollection<ListOfDiagnosis> selectedDiags = new ObservableCollection<ListOfDiagnosis>();

        public ObservableCollection<ListOfDiagnosis> diags
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

        public Anamnesis()
        {
           
                InitializeComponent();

                this.DataContext = this;
                diags = new ObservableCollection<ListOfDiagnosis>();

                

            try
            {

                var app = (App)Application.Current;
                _diagnosisController = app.diagnosisController;

                var diagnosisCSV = _diagnosisController.GetAllDiagnosis();
                if (diagnosisCSV != null)
                {
                    foreach (var diag in diagnosisCSV)
                    {
                        diags.Add(new ListOfDiagnosis { Dijagnoza = diag.Name });
                    }
                }
                else
                {
                    MessageBox.Show("Nema dijagnoza!");
                }
            }
            catch(Exception e) {
               
            }


                


                dpToday.SelectedDate = DateTime.Today;
                dpToday.IsEnabled = false;

                txtName.Text = Global.currPatient.name;
                txtLastname.Text = Global.currPatient.lastname;
                txtJMBG.Text = Global.currPatient.jmbg;
                txtAddress.Text = Global.currPatient.address;
                txtDateOfBirth.Text = Global.currPatient.dateOfBirth;

                txtName.IsEnabled = false;
                txtLastname.IsEnabled = false;
                txtJMBG.IsEnabled = false;
                txtAddress.IsEnabled = false;
                txtDateOfBirth.IsEnabled = false;

                //diags.Add(new ListOfDiagnosis { Dijagnoza = "Zapaljenje creva" });
                //diags.Add(new ListOfDiagnosis { Dijagnoza = "Upala pluća" });
                //diags.Add(new ListOfDiagnosis { Dijagnoza = "Trovanje" });
                //diags.Add(new ListOfDiagnosis { Dijagnoza = "Infekcija creva" });
                //diags.Add(new ListOfDiagnosis { Dijagnoza = "Dijabetes" });
                //diags.Add(new ListOfDiagnosis { Dijagnoza = "Deformitet" });
                //diags.Add(new ListOfDiagnosis { Dijagnoza = "Trbušni tifus" });
          
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
            NavigationService.Navigate(new Uri("/PatientCard.xaml", UriKind.Relative));
            MessageBox.Show("Uspešno ste sačuvali anamnezu!");
        }

        private void clkBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PatientCard.xaml", UriKind.Relative));
        }

        private void clkRecipe(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Recipe.xaml", UriKind.Relative));
        }

        private void clkTreatment(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Treatment.xaml", UriKind.Relative));
        }

        private void btnPrint(object sender, RoutedEventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream("izvestaj.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("Anamneza i objektivni pregled pacijenta");
            doc.Add(p);
            iTextSharp.text.Paragraph pDate = new iTextSharp.text.Paragraph("               Datum: " + DateTime.Now.ToString());
            doc.Add(pDate);

            doc.Close();
            MessageBox.Show("Uspešno izgenerisan izveštaj. Uskoro će se otvoriti PDF.");
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo()
            {
                FileName = "izvestaj.pdf"
            };
            proc.Start();

        }

        private void clkAddDiagnosis(object sender, RoutedEventArgs e)
        {
            Model.Doctor.Diagnosis diag = new Model.Doctor.Diagnosis();
            diag.Name = txtAddDiagnosis.Text;

            diag = _diagnosisController.AddDiagnosis(diag);        

            ListOfDiagnosis newDiag = new ListOfDiagnosis()
            {
                Dijagnoza = diag.Name
            };
            diags.Add(newDiag);

            if (!txtAddDiagnosis.Text.Equals(""))
            {
                txtAddDiagnosis.Clear();
            }
            else
            {
                MessageBox.Show("Morate uneti dijagnozu!");
            }
        }
    }
}
