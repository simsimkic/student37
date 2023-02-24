using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaFront.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private IPageViewModel PreviousPageViewModel { get; set; }
        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                {
                    _pageViewModels = new List<IPageViewModel>();
                }
                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
            {
                PageViewModels.Add(viewModel);
            }
            PreviousPageViewModel = CurrentPageViewModel;
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        private void OnGoToLoginScreen(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }

        private void OnGoToScheduleExaminationScreen(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }

        private void OnGoToExaminationsScreen(object obj)
        {
            PageViewModels[3] = new ExaminationsViewModel();
            ChangeViewModel(PageViewModels[3]);
        }

        private void OnGoToPreviousScreen(object obj)
        {
            ChangeViewModel(PreviousPageViewModel);
        }

        private void OnGoToRegistrationScreen(object obj)
        {
            ChangeViewModel(PageViewModels[4]);
        }

        private void OnGoToNextRegistrationScreen(object obj)
        {
            ChangeViewModel(PageViewModels[5]);
        }

        private void OnLogin(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnRegister(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGoToTherapiesScreen(object obj)
        {
            ChangeViewModel(PageViewModels[6]);
        }
        
        private void OnGoToExaminationRecommendationScreen(object obj)
        {
            ChangeViewModel(PageViewModels[7]);
        }

        private void OnGoToMainScreen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGoToQuestionsScreen(object obj)
        {
            ChangeViewModel(PageViewModels[8]);
        }

        private void OnGoToProfileScreen(object obj)
        {
            ChangeViewModel(PageViewModels[9]);
        }

        private void OnGoToExaminationViewScreen(object obj)
        {
            ChangeViewModel(new ExaminationViewViewModel());
        }

        public MainWindowViewModel()
        {
            PageViewModels.Add(new MainViewModel());
            PageViewModels.Add(new LoginViewModel());
            PageViewModels.Add(new ScheduleExaminationViewModel());
            PageViewModels.Add(new ExaminationsViewModel());
            PageViewModels.Add(new Registration1ViewModel());
            PageViewModels.Add(new Registration2ViewModel());
            PageViewModels.Add(new TherapiesViewModel());
            PageViewModels.Add(new ExaminationRecommendationViewModel());
            PageViewModels.Add(new QuestionsViewModel());
            PageViewModels.Add(new ProfileViewModel());

            CurrentPageViewModel = PageViewModels[1];

            Mediator.Subscribe("GoToLoginScreen", OnGoToLoginScreen);
            Mediator.Subscribe("GoToPreviousScreen", OnGoToPreviousScreen);
            Mediator.Subscribe("GoToScheduleExaminationScreen", OnGoToScheduleExaminationScreen);
            Mediator.Subscribe("GoToExaminationsScreen", OnGoToExaminationsScreen);
            Mediator.Subscribe("GoToRegistrationScreen", OnGoToRegistrationScreen);
            Mediator.Subscribe("GoToNextRegistrationScreen", OnGoToNextRegistrationScreen);
            Mediator.Subscribe("GoToTherapiesScreen", OnGoToTherapiesScreen);
            Mediator.Subscribe("Login", OnLogin);
            Mediator.Subscribe("Register", OnRegister);
            Mediator.Subscribe("GoToExaminationRecommendationScreen", OnGoToExaminationRecommendationScreen);
            Mediator.Subscribe("GoToMainScreen", OnGoToMainScreen);
            Mediator.Subscribe("GoToQuestionsScreen", OnGoToQuestionsScreen);
            Mediator.Subscribe("GoToProfileScreen", OnGoToProfileScreen);
            Mediator.Subscribe("GoToExaminationView", OnGoToExaminationViewScreen);

        }
    }
}
