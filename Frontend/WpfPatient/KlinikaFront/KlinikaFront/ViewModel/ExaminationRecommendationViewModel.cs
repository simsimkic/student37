using KlinikaFront.DB;
using KlinikaFront.User;
using KlinikaFront.Utilities;
using Model.Doctor;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class ExaminationRecommendationViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _goToScheduleExamination;
        private ICommand _findAppointment;
        private ICommand _confirm;
        private ICommand _updateHelp;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public List<Doctor> Doctors
        {
            get
            {
                return DoctorsDB.Instance.Doctors;
            }
        }
        public string ShortDate {
            get
            {
                if (RecommendedAppointment == null) return "";
                return RecommendedAppointment.StartTime.ToString("dd.MM.yyyy.");
            }
        }
        public string DayOfWeek
        {
            get
            {
                if (RecommendedAppointment == null) return "";
                switch(RecommendedAppointment.StartTime.DayOfWeek)
                {
                    case System.DayOfWeek.Monday:
                        return "Ponedeljak";
                    case System.DayOfWeek.Tuesday:
                        return "Utorak";
                    case System.DayOfWeek.Wednesday:
                        return "Sreda";
                    case System.DayOfWeek.Thursday:
                        return "Četvrtak";
                    case System.DayOfWeek.Friday:
                        return "Petak";
                    case System.DayOfWeek.Saturday:
                        return "Subota";
                    case System.DayOfWeek.Sunday:
                        return "Nedelja";
                    default:
                        return "";
                }
                    
            }
        }
        public string Time
        {
            get
            {
                if (RecommendedAppointment == null) return "";
                return RecommendedAppointment.StartTime.ToString("HH:mm");
            }
        }
        public Doctor SelectedDoctor { get; set; }
        public bool PriorityDoctor { get; set; }
        public bool PriorityDate { get; set; }
        public bool ShowAppointment { get; set; } = false;
        public Appointment RecommendedAppointment { get; set; }

        public ExaminationRecommendationViewModel()
        {
            Mediator.Subscribe("ShowAppointment", EnableAppointment);
        }

        private void EnableAppointment(object obj)
        {
            ShowAppointment = true;
            OnPropertyChanged("ShowAppointment");
            OnPropertyChanged("RecommendedAppointment");
            OnPropertyChanged("ShortDate");
            OnPropertyChanged("DayOfWeek");
            OnPropertyChanged("Time");
        }

        public ICommand UpdateHelp
        {
            get
            {
                return _updateHelp ?? (_updateHelp = new RelayCommand(x =>
                {
                    PageHelp = false;
                    OnPropertyChanged("ShowHelp");
                }));
            }
        }

        public bool PageHelp { get; set; } = true;
        public bool ShowHelp
        {
            get
            {
                return PageHelp && Config.Instance.HelpEnabled;
            }
        }

        public ICommand GoToPrevious
        {
            get
            {
                return _goToPrevious ?? (_goToPrevious = new RelayCommand(x =>
                {
                    ShowAppointment = false;
                    OnPropertyChanged("ShowAppointment");
                    Mediator.Notify("GoToMainScreen", "");
                }));
            }
        }

        public ICommand GoToScheduleExamination
        {
            get
            {
                return _goToScheduleExamination ?? (_goToScheduleExamination = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToScheduleExaminationScreen", "");
                }));
            }
        }

        public ICommand FindAppointment
        {
            get
            {
                return _findAppointment ?? (_findAppointment = new RelayCommand(x =>
                {
                    RecommendedAppointment = new Appointment(0, StartDate, StartDate, AppointmentType.examination, new Model.Manager.Room("6P"), SelectedDoctor, CurrentUser.Instance.Patient);
                    Mediator.Notify("ShowAppointment", "");
                }));
            }
        }

        public ICommand Confirm
        {
            get
            {
                return _confirm ?? (_confirm = new RelayCommand(x =>
                {
                    AppointmentsDB.Instance.Appointments.Add(RecommendedAppointment);
                    ShowAppointment = false;
                    OnPropertyChanged("ShowAppointment");
                    Mediator.Notify("GoToMainScreen", "");
                }));
            }
        }
    }
}
