using Controller.Documents;
using Controller.Users;
using KlinikaFront.DB;
using KlinikaFront.Utilities;
using Model.Doctor;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class QuestionsViewModel : BaseViewModel, IPageViewModel
    {
        DoctorController doctorController = new DoctorController();
        QuestionController questionController = new QuestionController();
        private ICommand _goToPrevious;
        private ICommand _submitQuestion;

        public string Title { get; set; }
        public string Content { get; set; }
        public List<Doctor> Doctors {
            get
            {
                return DoctorsDB.Instance.Doctors;
            }
        }
        public bool MessageVisible {
            get
            {
                return !Questions.Any();
            }
        }
        public Doctor SelectedDoctor { get; set; }
        public ObservableCollection<Question> Questions {
            get
            {
                return QuestionsDB.Instance.Questions;
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

        public ICommand SubmitQuestion
        {
            get
            {
                return _submitQuestion ?? (_submitQuestion = new RelayCommand(x =>
                {
                    Question toSubmit = new Question(0, Title, Content, SelectedDoctor);
                    Questions.Add(toSubmit);
                    Title = "";
                    Content = "";
                    SelectedDoctor = null;
                    OnPropertyChanged("Title");
                    OnPropertyChanged("Content");
                    OnPropertyChanged("SelectedDoctor");
                    OnPropertyChanged("MessageVisible");
                    OnPropertyChanged("Questions");
                    
                }));
            }
        }
    }
}
