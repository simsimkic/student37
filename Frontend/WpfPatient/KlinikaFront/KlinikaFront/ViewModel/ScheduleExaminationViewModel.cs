using KlinikaFront.DB;
using KlinikaFront.User;
using KlinikaFront.Utilities;
using Model.Doctor;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class ScheduleExaminationViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _goToMain;
        private ICommand _confirm;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public List<Doctor> Doctors
        {
            get
            {
                return DoctorsDB.Instance.Doctors;
            }
        }

        public List<Appointment> Appointments
        {
            get
            {
                Console.WriteLine("Zovem appointments");
                List<Appointment> list = new List<Appointment>();
                if (SelectedDoctor == null) return list;
                list.Add(new Appointment(0, StartDate, StartDate, AppointmentType.examination,
                    new Model.Manager.Room("6P"), SelectedDoctor, CurrentUser.Instance.Patient));
                list.Add(new Appointment(0, StartDate.AddMinutes(45), StartDate, AppointmentType.examination,
                    new Model.Manager.Room("6A"), SelectedDoctor, CurrentUser.Instance.Patient));
                list.Add(new Appointment(0, StartDate.AddMinutes(90), StartDate, AppointmentType.examination,
                    new Model.Manager.Room("6A"), SelectedDoctor, CurrentUser.Instance.Patient));
                return list;
            }
        }
        public Doctor SelectedDoctor { get; set; }
        public void DoctorPropertyChanged()
        {
            OnPropertyChanged("SelectedDoctor");
            OnPropertyChanged("Appointments");
        }
        public Appointment SelectedAppointment { get; set; }
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

        public ICommand GoToMain
        {
            get
            {
                return _goToMain ?? (_goToMain = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToMainScreen", "");
                }));
            }
        }

        public ICommand Confirm
        {
            get
            {
                return _confirm ?? (_confirm = new RelayCommand(x =>
                {
                    AppointmentsDB.Instance.Appointments.Add(SelectedAppointment);
                    Mediator.Notify("GoToMainScreen", "");
                }));
            }
        }


    }
}
