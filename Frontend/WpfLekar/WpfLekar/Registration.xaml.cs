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
using System.ComponentModel;

using Controller.Users;
using Model.Manager;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page, INotifyPropertyChanged
    {

        private readonly DoctorController _doctorController;
        private readonly PatientController _patientController;
        public List<Model.User.Role> roles;

        public Registration()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = (App)Application.Current;
            _doctorController = app.doctorController;
            _patientController = app.patientController;

            roles = new List<Model.User.Role>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _password;
        private String _jmbg;
        private String _email;
        private String _username;
        private String _name;
        private String _lastname;
        private String _telephoneNumber;
        private String _address;


        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                if (value != _lastname)
                {
                    _lastname = value;
                    OnPropertyChanged("Lastname");

                }
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged("Address");

                }
            }
        }


        public string TelephoneNumber
        {
            get
            {
                return _telephoneNumber;
            }
            set
            {
                if (value != _telephoneNumber)
                {
                    _telephoneNumber = value;
                    OnPropertyChanged("TelephoneNumber");

                }
            }
        }


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");

                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");

                }
            }
        }


        public string Jmbg
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("Jmbg");

                }
            }
        }


        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");

                }
            }
        }


        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("Username");

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

        private void clkSave(object sender, RoutedEventArgs e)
        {
            Dto.RegisterUserDTO registerUserDto = new Dto.RegisterUserDTO();

            if (!txtName.Text.Equals("") && !txtJmbg.Text.Equals("") && !txtAddress.Text.Equals("") && !txtPassword.Text.Equals("") && !txtSurname.Text.Equals("") && !txtTelephoneNumber.Text.Equals("") && !txtUserName.Text.Equals(""))
            {

                roles.Add(Model.User.Role.doctor);
                //roles.Add(Model.User.Role.patient);
                registerUserDto.Jmbg = txtJmbg.Text;
                registerUserDto.Name = txtName.Text;
                registerUserDto.LastName = txtSurname.Text;
                registerUserDto.Username = txtUserName.Text;
                registerUserDto.Password = txtPassword.Text;
                registerUserDto.Email = txtEmail.Text;
                registerUserDto.Roles = roles;
                if (!txtAddress.Text.Equals("")) {
                    registerUserDto.Address = new Model.User.Address(0, txtAddress.Text);
                    registerUserDto.Address.City = new Model.User.City("Novi Sad");
                    registerUserDto.Address.City.Municipality = new Model.User.Municipality("Novi Sad");
                    registerUserDto.Address.City.Municipality.Country = new Model.User.Country("Srbija");
                }
                registerUserDto.MaritalStatus = Model.Patient.MaritalStatus.unmarried;
                registerUserDto.Phone = txtTelephoneNumber.Text;
                registerUserDto.BirthDate = DateTime.Now;
                registerUserDto.WorkTime = new WorkTime() { Id = 0 };
                //registerUserDto.Sex = Model.Patient.Sex.female;
                _doctorController.RegisterDoctor(registerUserDto); 

                NavigationService.Navigate(new Uri("/LogIn.xaml", UriKind.Relative));
                MessageBox.Show("Uspešno ste se registrovali!");
            }
            else {
                MessageBox.Show("Niste popunili sva obavezna polja!");
            }
                
        }

        private void clkBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

      
    }
}
