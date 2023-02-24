using Dao.MedicalServices;
using Dao.MedicalServices.CSVImpl;
using KlinikaFront.DB;
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
    class ExaminationViewViewModel : BaseViewModel, IPageViewModel
    {
        public Appointment Examination {
            get
            {
                return AppointmentsDB.Instance.Selected;
            }
        }
        public string DoctorName {
            get
            {
                return Examination.Doctor.Name + " " + Examination.Doctor.LastName;
            }
            set
            {
                return;
            }
        }

        public string Date
        {
            get
            {
                return Examination.StartTime.ToString("dd.MM.yyyy.");
            }
            set
            {
                return;
            }
        }
        public string Time
        {
            get
            {
                return Examination.StartTime.ToString("hh:mm");
            }
            set
            {
                return;
            }
        }
        public string Room
        {
            get
            {
                return Examination.Room.Id;
            }
            set
            {
                return;
            }
        }
        private ICommand _goToPrevious;
        private ICommand _abortExamination;
        public bool IsAbortEnabled { get; set; }

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

        public ICommand AbortExamination
        {
            get
            {
                return _abortExamination ?? (_abortExamination = new RelayCommand(x =>
                {
                    AppointmentsDB.Instance.Appointments.Remove(AppointmentsDB.Instance.Selected);
                    Mediator.Notify("GoToExaminationsScreen", "");
                }));
            }
        }
    }
}
