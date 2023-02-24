
using Controller.Users;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfLekar.Modeli;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page, INotifyPropertyChanged
    {

        private readonly DoctorController _doctorController;


        public LogIn()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = (App)Application.Current;
            _doctorController = app.doctorController;

            var doctorCSV = _doctorController.GetAllDoctors();

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _name;
        private string _password;
        

        public string Username
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Username");
                }
            }
        }


        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
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

        private void clkRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

        private void clkLogIn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/LogIn.xaml", UriKind.Relative));
        }

        private void clkOk(object sender, RoutedEventArgs e)
        {
            Global.doc = new Model.Doctor.Doctor();
            string username = txtUserName.Text;
            string password = txtPassword.Password;
            Global.doc = _doctorController.LoginDoctor(username, password);

            if (Global.doc != null)
            {
                NavigationService.Navigate(new Uri("/Tutorial.xaml", UriKind.Relative));
            }
            else {
                MessageBox.Show("Greška prilikom prijavljivanja. Pokušajte ponovo.");
            }
            
        }

        private void clkLinkRegistration(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

        private void clkLinkForgotPassword(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ForgotPassword.xaml", UriKind.Relative));
        }

    }
}
