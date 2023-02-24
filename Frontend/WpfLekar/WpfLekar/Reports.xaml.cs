using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
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


namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Page
    {

        public ObservableCollection<ListOfReports> reports
        {
            get;
            set;
        }

        public Reports()
        {
            InitializeComponent();
            this.DataContext = this;
            reports = new ObservableCollection<ListOfReports>();
            reports.Add(new ListOfReports { Datum = "04-04-2019", Dijagnoza = "Zapaljenje creva", Izvestaj = "izvestaj78526.pdf" });
            reports.Add(new ListOfReports { Datum = "10-06-2020", Dijagnoza = "Upala pluća", Izvestaj = "izvestaj70026.pdf" });
      
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

        private void clkBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PatientCard.xaml", UriKind.Relative));
        }

        private void btnPrint(object sender, RoutedEventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream("izvestaj.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("Anamneza i objektivni pregled pacijenta");
            doc.Add(p);
            doc.Close();
            MessageBox.Show("Uspešno izgenerisan izveštaj. Uskoro će se otvoriti PDF.");
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo()
            {
                FileName = "izvestaj.pdf"
            };
            proc.Start();

        }

    }
}
