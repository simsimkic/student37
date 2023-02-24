using Controller.Users;
using Dto;
using Klinika.Controller.Users;
using Klinika.Service.Users;
using KlinikaFront.User;
using KlinikaFront.Utilities;
using Model.Patient;
using Model.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class Registration1ViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToNextRegistration;
        private ICommand _goToLogin;
        public static RegisterUserDTO RegisterUserDTO { get; set; } = new RegisterUserDTO();
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public ICommand GoToNextRegistration
        {
            get
            {
                return _goToNextRegistration ?? (_goToNextRegistration = new RelayCommand(x =>
                {
                    RegisterUserDTO.Password = Password.ToString();
                    Mediator.Notify("GoToNextRegistrationScreen", "");
                }));
            }
        }

        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ?? (_goToLogin = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToLoginScreen", "");
                }));
            }
        }
    }
    class Registration2ViewModel: BaseViewModel, IPageViewModel, INotifyDataErrorInfo
    {
        private AddressController addressController = new AddressController();
        private ICommand _goToPrevious;
        private ICommand _goToLogin;
        private ICommand _register;
        private ICommand _updateMunicipalities;
        private ICommand _updateCities;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public RegisterUserDTO RegisterUserDTO { get; } = Registration1ViewModel.RegisterUserDTO;
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public bool IsOther { get; set; }
        public List<Country> Countries { get; set; }
        public Country SelectedCountry { get; set; }
        public List<Municipality> Municipalities { get; set; }
        public Municipality SelectedMunicipality { get; set; }
        public List<City> Cities { get; set; }
        public City SelectedCity { get; set; }

        public Registration2ViewModel()
        {
            Countries = (List<Country>) addressController.GetAllCountries();
        }

        public ICommand UpdateMunicipalities
        {
            get
            {
                return _updateMunicipalities ?? (_updateMunicipalities = new RelayCommand(x =>
                {
                    Municipalities =(List<Municipality>)addressController.GetMunicipalitiesByCountry(SelectedCountry.Name);
                    OnPropertyChanged("Municipalities");
                }));
            }
        }

        public ICommand UpdateCities
        {
            get
            {
                return _updateCities ?? (_updateCities = new RelayCommand(x =>
                {
                    Cities = (List<City>)addressController.GetCitiesByMunicipality(SelectedMunicipality.Name);
                    OnPropertyChanged("Cities");
                }));
            }
        }
        public ICommand GoToPrevious
        {
            get
            {
                return _goToPrevious ?? (_goToPrevious = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToPreviousScreen", "");
                }));
            }
        }

        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ?? (_goToLogin = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToLoginScreen", "");
                }));
            }
        }

        public ICommand Register
        {
            get
            {
                return _register ?? (_register = new RelayCommand(x =>
                {
                    if (IsMale) Registration1ViewModel.RegisterUserDTO.Sex = Sex.male;
                    else if (IsFemale) Registration1ViewModel.RegisterUserDTO.Sex = Sex.female;
                    else Registration1ViewModel.RegisterUserDTO.Sex = Sex.other;
                    Address address = new Address(0);
                    List<Role> roles = new List<Role>();
                    roles.Add(Role.patient);
                    Registration1ViewModel.RegisterUserDTO.Roles = roles;
                    Registration1ViewModel.RegisterUserDTO.Address = address;
                    Registration1ViewModel.RegisterUserDTO.Address.City = SelectedCity;
                    Registration1ViewModel.RegisterUserDTO.Address.City.Municipality = SelectedMunicipality;
                    Registration1ViewModel.RegisterUserDTO.Address.City.Municipality.Country = SelectedCountry;
                    Console.WriteLine(RegisterUserDTO.Jmbg + RegisterUserDTO.Name + RegisterUserDTO.LastName
                        + RegisterUserDTO.Username + RegisterUserDTO.Password + RegisterUserDTO.Email
                        + RegisterUserDTO.Roles + RegisterUserDTO.Address
                        + RegisterUserDTO.MaritalStatus + RegisterUserDTO.Phone
                        + RegisterUserDTO.BirthDate + RegisterUserDTO.Sex);
                    PatientController controller = new PatientController();
                    CurrentUser.Instance.Patient = controller.RegisterPatient(Registration1ViewModel.RegisterUserDTO);
                    if (CurrentUser.Instance.Patient == null)
                    {
                        Mediator.Notify("GoToRegistrationScreen", "");
                    }
                    else
                    {
                        Mediator.Notify("Register", "");
                    }
                    
                }));
            }
        }

        public bool HasErrors { get; set; } = false;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || (!HasErrors))
                return null;
            return new List<string>() { "Pogresan unos." };
        }
    }
}
