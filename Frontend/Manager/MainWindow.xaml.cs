using Manager.Account;
using Manager.Other;
using Manager.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
using Manager.Model;
using Model.Manager;
using Controller.Clinic;

namespace Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MedicineController _medicineController;
        public MainWindow()
        {
            InitializeComponent();

            var app = (App)System.Windows.Application.Current;
            _medicineController = app.medicineController;

            btnEmployees.Focus();
            Managerr user = Global.managers[Global.userID];
            lblMname.Content = user.Name + ", upravnik";
            
            if (user.Uri.Length != 0)
            {
                imgUser.Source = new BitmapImage(new Uri(user.Uri));
            }
            else if (user.Gender == GenderEnum.female)
            {
                imgUser.Source = new BitmapImage(new Uri(@"../Resources/female-nopicture.png", UriKind.Relative));
            }
        }

// NALOG
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var wi = new Profile();
            wi.Show();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AccSettings();
            wi.Show();
        }

        private void miPassword_Click(object sender, RoutedEventArgs e)
        {
            var wi = new Password();
            wi.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            
            var wi = new Login(Global.userID);
            wi.Show();
            Global.userID = "";
            this.Close();
        }


// EVIDENCIJE
        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AllEmployees();
            wi.Show();
        }

        private void Equip_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AllEquipment();
            wi.Show();
        }

        private void Room_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AllRooms();
            wi.Show();
        }

        private void Medicine_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AllMedicines();
            wi.Show();
        }
// DODAVANJE
        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AddEditEmployee();
            wi.Show();
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AddEditRoom();
            wi.Show();
        }

        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AddMedicine();
            wi.Show();
        }
// FUNKICJE
        private void btnRepair_Click(object sender, RoutedEventArgs e)
        {
            var wi = new Reparations();
            wi.Show();
        }

        private void btnRenovate_Click(object sender, RoutedEventArgs e)
        {
            var wi = new Renovations();
            wi.Show();
        }

        private void btnAddEquip_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AddEditEquip();
            wi.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter.GetInstance(doc, new FileStream("Izvestaj.pdf", FileMode.Create));
            doc.Open();

            iTextSharp.text.Paragraph pCaption = new iTextSharp.text.Paragraph("Izvestaj o trenutnoj kolicini lekova",
                new Font(Font.FontFamily.HELVETICA, 18, Font.NORMAL, BaseColor.BLACK));
            pCaption.Alignment = Element.ALIGN_CENTER;
            doc.Add(pCaption);
            doc.Add(new Chunk("\n"));

            iTextSharp.text.Paragraph pDateate = new iTextSharp.text.Paragraph("     Datum: " + DateTime.Now.ToString());
            doc.Add(pDateate);

            Managerr user = Global.managers[Global.userID];
            string gen;
            if (user.Gender == GenderEnum.male)
                gen = "     Zahtevao: ";
            else
                gen = "     Zahtevala: ";
            iTextSharp.text.Paragraph pUser = new iTextSharp.text.Paragraph(gen + user.Name + " " + user.LastName);
            doc.Add(pUser);
            doc.Add(new Chunk("\n"));

            PdfPTable t = new PdfPTable(2);
            
            PdfPCell cId = new PdfPCell(new Phrase("ID leka", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.WHITE)));
            cId.BackgroundColor = new BaseColor(54, 70, 243);
            cId.HorizontalAlignment = 1;
            PdfPCell cAmount = new PdfPCell(new Phrase("Kolicina", new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.WHITE)));
            cAmount.BackgroundColor = new BaseColor(54, 70, 243);
            cAmount.HorizontalAlignment = 1;
            t.AddCell(cId);
            t.AddCell(cAmount);

            foreach(Medicine m in _medicineController.GetAllMedicines())
            {
                t.AddCell(m.Tag);
                t.AddCell(m.Amount.ToString());
            }
            doc.Add(t);

            doc.Close();
            System.Windows.MessageBox.Show("Uspesno izgenerisan fajl!", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo()
            {
                FileName = "Izvestaj.pdf"
            };
            proc.Start();
        }

        private void cmdEmployee_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Employees_Click(sender, e);
        }

        private void cmdEquipment_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Equip_Click(sender, e);
        }

        private void cmdRoom_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Room_Click(sender, e);
        }

        private void cmdMedicine_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Medicine_Click(sender, e);
        }
    }

}
