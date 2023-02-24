using Controller.Users;
using KlinikaFront.User;
using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class LoginViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _login;
        private ICommand _goToRegistration;
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand Login
        {
            get
            {
                return _login ?? (_login = new RelayCommand(x =>
                {
                    PatientController controller = new PatientController();
                    CurrentUser.Instance.Patient = controller.LoginPatient(Username, Password);
                    if(CurrentUser.Instance.Patient != null)
                    {
                        Username = "";
                        Password = "";
                        Mediator.Notify("Login", "");
                    }
                }));
            }
        }

        public ICommand GoToRegistration
        {
            get
            {
                return _goToRegistration ?? (_goToRegistration = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToRegistrationScreen", "");
                }));
            }
        }
    }
}
