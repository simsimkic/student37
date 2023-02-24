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
using WpfLekar.Modeli;
using System.Windows.Shapes;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Page
    {
        static List<Medicine> medicineList = new List<Medicine>();

        public ObservableCollection<ListOfDiagnosis> diags
        {
            get;
            set;
        }

        public ObservableCollection<MedicinesToValidate> diagMeds
        {
            get;
            set;
        }

        public ObservableCollection<MedicinesToValidate> meds
        {
            get;
            set;
        }


        public Recipe()
        {
            InitializeComponent();
            this.DataContext = this;

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

            diags = new ObservableCollection<ListOfDiagnosis>();
            //diags.Add(new ListOfDiagnosis { Dijagnoza = "Zapaljenje creva" });
            //diags.Add(new ListOfDiagnosis { Dijagnoza = "Upala pluća" });
            //diags.Add(new ListOfDiagnosis { Dijagnoza = "Trovanje" });

            diagMeds = new ObservableCollection<MedicinesToValidate>();
            diagMeds.Add(new MedicinesToValidate { Naziv = "Brufen", Doza = "300mg", Dijagnoza = "Glavobolja", NezeljenaDejstva = "Mučnina", Sastojci = "Ibuprofen" });

            meds = new ObservableCollection<MedicinesToValidate>();
            meds.Add(new MedicinesToValidate { Naziv = "Brufen", Doza = "300mg", Dijagnoza = "Glavobolja", NezeljenaDejstva = "Mučnina", Sastojci = "Ibuprofen" });
            meds.Add(new MedicinesToValidate { Naziv = "Enalapril", Doza = "10mg", Dijagnoza = "Povišeni protisak", NezeljenaDejstva = "Kašalj", Sastojci = "Enalapril" });
            meds.Add(new MedicinesToValidate { Naziv = "Bromazepam", Doza = "3mg", Dijagnoza = "Upala bubrega", NezeljenaDejstva = "Pospanost", Sastojci = "Laktoza" });


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

    }
}
