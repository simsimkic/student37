using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KlinikaFront.User;
using Model.Patient;
using KlinikaFront.DB;

namespace KlinikaFront.ViewModel
{
    class MainViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToIndex;
        private ICommand _toggleMenu;
        private ICommand _goToLogin;
        private ICommand _goToExaminationRecommendation;
        private ICommand _goToExaminations;
        private ICommand _goToTherapies;
        private ICommand _goToQuestions;
        private ICommand _goToProfile;
        private ICommand _updateHelp;
        private ICommand _toggleHelp;
        public bool ShowHelp
        {
            get
            {
                return PageHelp && HelpEnabled;
            }
        }
        public bool PageHelp { get; set; } = true;
        public bool HelpEnabled
        {
            get
            {
                return Config.Instance.HelpEnabled;
            }
            set
            {
                Config.Instance.HelpEnabled = value;
            }
        }
        public ICommand UpdateHelp
        {
            get
            {
                return _updateHelp ?? (_updateHelp = new RelayCommand(x =>
                {
                    OnPropertyChanged("ShowHelp");
                }));
            }
        }
        public bool MenuOpened { get; set; } = false;
        public Patient User
        {
            get
            {
                return CurrentUser.Instance.Patient;
            }
        }
        public ICommand GoToIndex
        {
            get
            {
                return _goToIndex ?? (_goToIndex = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToIndexScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        public ICommand GoToProfile
        {
            get
            {
                return _goToProfile ?? (_goToProfile = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToProfileScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        public ICommand ToggleMenu
        {
            get
            {
                return _toggleMenu ?? (_toggleMenu = new RelayCommand(x =>
                {
                    Mediator.Notify("ToggleMenu", "");
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
                    CurrentUser.Instance.Patient = null;
                    MenuOpened = false;
                }));
            }
        }

        public ICommand GoToExaminationRecommendation
        {
            get
            {
                return _goToExaminationRecommendation ?? (_goToExaminationRecommendation = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToExaminationRecommendationScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        public ICommand GoToExaminations
        {
            get
            {
                return _goToExaminations ?? (_goToExaminations = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToExaminationsScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        public ICommand GoToTherapies
        {
            get
            {
                return _goToTherapies ?? (_goToTherapies = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToTherapiesScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        public ICommand GoToQuestions
        {
            get
            {
                return _goToQuestions ?? (_goToQuestions = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToQuestionsScreen", "");
                }));
            }
        }

        private void OnToggleMenu(object obj)
        {
            MenuOpened = !MenuOpened;
            OnPropertyChanged("MenuOpened");
        }

        public ICommand ToggleHelp
        {
            get
            {
                return _toggleHelp ?? (_toggleHelp = new RelayCommand(x =>
                {
                    HelpEnabled = !HelpEnabled;
                    OnPropertyChanged("HelpEnabled");
                }));
            }
        }

        public MainViewModel()
        {
            Mediator.Subscribe("ToggleMenu", OnToggleMenu);
        }

    }
}
