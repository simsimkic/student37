using Controller.Users;
using Klinika.Controller.Users;
using Microsoft.Win32;
using Model.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MyAccount.xaml
    /// </summary>
    public partial class MyAccount : Page
    {
        public static string profilePicturePath;
        private readonly DoctorController _doctorController;

        public MyAccount()
        {
            InitializeComponent();


            txtName.Text = Global.doc.Name;
            txtLastname.Text = Global.doc.LastName;
            txtJMBG.Text = Global.doc.Jmbg;
            txtContact.Text = Global.doc.Phone;
            txtDateOfBirth.Text = DateTime.Now.ToString();
            txtEmail.Text = Global.doc.Email;
            txtUsername.Text = Global.doc.Username;

            txtName.IsEnabled = false;
            txtLastname.IsEnabled = false;
            txtPassword.IsEnabled = false;
            txtContact.IsEnabled = false;
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

        private void clkSchedule(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MySchedule.xaml", UriKind.Relative));
        }

        private void clkValidation(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ValidationMedicins.xaml", UriKind.Relative));
        }

        private void clkQuestions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/QuestionsFromPatients.xaml", UriKind.Relative));
        }

        private void clkChat(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChatWithColleagues.xaml", UriKind.Relative));
        }

        private void clkCurrent(object sender, RoutedEventArgs e)
        {

            if (Global.patients.ContainsKey("branka"))
            {
                Global.currPatient = Global.patients["branka"];
                NavigationService.Navigate(new Uri("/PatientCard.xaml", UriKind.Relative));
            }
        }

        private void clkAdd(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "Izaberite novu profilnu sliku.";
            fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (.jpg;.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (.png)|.png";

            if (fileDialog.ShowDialog() == true)
            {
                profilePicturePath = fileDialog.FileName;
                image.Source = new BitmapImage(new Uri(profilePicturePath));
            }
        }

        private void clkEdit(object sender, RoutedEventArgs e)
        {
            txtName.IsEnabled = true;
            txtLastname.IsEnabled = true;
            txtJMBG.IsEnabled = true;
            txtPassword.IsEnabled = true;
            txtContact.IsEnabled = true;
            txtDateOfBirth.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtUsername.IsEnabled = true;

            Global.doc.Name = txtName.Text;
            Global.doc.LastName = txtLastname.Text;
            Global.doc.Phone = txtContact.Text;
            Global.doc.Email = txtEmail.Text;
            Global.doc.Username = txtUsername.Text;

           // doctorController. SAVE URADITI

        }

        
    }
}
