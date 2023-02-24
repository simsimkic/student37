using KlinikaFront.DB;
using KlinikaFront.Utilities;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class ExaminationsViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _previousWeek;
        private ICommand _nextWeek;
        private ICommand _selectAppointment;
        private ICommand _updateHelp;

        public ObservableCollection<Appointment> MondayAppointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Appointment> TuesdayAppointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Appointment> WednesdayAppointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Appointment> ThursdayAppointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Appointment> FridayAppointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Appointment> SaturdayAppointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Appointment> SundayAppointments { get; set; } = new ObservableCollection<Appointment>();
        public bool[] DayNotEmpty { get; set; } = { false, false, false, false, false, false, false };
        public string WeekString { get; private set; }
        public DateTime StartOfWeek { get; private set; }
        public List<DateTime> DaysOfWeek { get; set; } = new List<DateTime>();
        public List<string> DayStrings { get; set; } = new List<string>();

        public ExaminationsViewModel()
        {

            int day = (int)DateTime.Now.DayOfWeek;
            StartOfWeek = DateTime.Now.AddDays(-day + 1);
            WeekString = StartOfWeek.ToString("dd.MM.") + " - " + StartOfWeek.AddDays(7).ToString("dd.MM.");
            PopulateWeek();

        }

        private void PopulateWeek()
        {
            DaysOfWeek.Clear();
            DayStrings.Clear();
            for (int i = 0; i <= 6; i++)
            {
                DateTime dayOfWeek = StartOfWeek.AddDays(i);
                DaysOfWeek.Add(dayOfWeek);
                DayStrings.Add(dayOfWeek.ToString("dd.MM.yyyy"));
                DayNotEmpty[i] = false;
            }
            OnPropertyChanged("DayStrings");
            MondayAppointments = new ObservableCollection<Appointment>();
            TuesdayAppointments = new ObservableCollection<Appointment>();
            WednesdayAppointments = new ObservableCollection<Appointment>();
            ThursdayAppointments = new ObservableCollection<Appointment>();
            FridayAppointments = new ObservableCollection<Appointment>();
            SaturdayAppointments = new ObservableCollection<Appointment>();
            SundayAppointments = new ObservableCollection<Appointment>();
            foreach (Appointment a in AppointmentsDB.Instance.Appointments)
            {
                if (a.StartTime.Date == DaysOfWeek[0].Date)
                {
                    MondayAppointments.Add(a);
                    DayNotEmpty[0] = true;
                }
                else if (a.StartTime.Date == DaysOfWeek[1].Date)
                {
                    TuesdayAppointments.Add(a);
                    DayNotEmpty[1] = true;
                }
                else if (a.StartTime.Date == DaysOfWeek[2].Date)
                {
                    WednesdayAppointments.Add(a);
                    DayNotEmpty[2] = true;
                }
                else if (a.StartTime.Date == DaysOfWeek[3].Date)
                {
                    ThursdayAppointments.Add(a);
                    DayNotEmpty[3] = true;
                }
                else if (a.StartTime.Date == DaysOfWeek[4].Date)
                {
                    FridayAppointments.Add(a);
                    DayNotEmpty[4] = true;
                }
                else if (a.StartTime.Date == DaysOfWeek[5].Date)
                {
                    SaturdayAppointments.Add(a);
                    DayNotEmpty[5] = true;
                }
                else if (a.StartTime.Date == DaysOfWeek[6].Date)
                {
                    SundayAppointments.Add(a);
                    DayNotEmpty[6] = true;
                }
                OnPropertyChanged("SundayAppointments");
                OnPropertyChanged("SaturdayAppointments");
                OnPropertyChanged("FridayAppointments");
                OnPropertyChanged("ThursdayAppointments");
                OnPropertyChanged("WednesdayAppointments");
                OnPropertyChanged("TuesdayAppointments");
                OnPropertyChanged("MondayAppointments");
                OnPropertyChanged("DayNotEmpty");
            }
        }

        public ICommand GoToPrevious
        {
            get
            {
                return _goToPrevious ?? (_goToPrevious = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToMainScreen", "");
                }));
            }
        }

        public ICommand PreviousWeek
        {
            get
            {
                return _previousWeek ?? (_previousWeek = new RelayCommand(x =>
                {
                    StartOfWeek = StartOfWeek.AddDays(-7);
                    WeekString = StartOfWeek.ToString("dd.MM.") + " - " + StartOfWeek.AddDays(7).ToString("dd.MM.");
                    OnPropertyChanged("WeekString");
                    PopulateWeek();
                }));
            }
        }

        public ICommand NextWeek
        {
            get
            {
                return _nextWeek ?? (_nextWeek = new RelayCommand(x =>
                {
                    StartOfWeek = StartOfWeek.AddDays(7);
                    WeekString = StartOfWeek.ToString("dd.MM.") + " - " + StartOfWeek.AddDays(7).ToString("dd.MM.");
                    OnPropertyChanged("WeekString");
                    PopulateWeek();
                }));
            }
        }

        public ICommand SelectAppointment
        {
            get
            {
                return _selectAppointment ?? (_selectAppointment = new RelayCommand<Appointment>(OnSelectAppointment, null));
            }
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


        private void OnSelectAppointment(Appointment appointment)
        {
            AppointmentsDB.Instance.Selected = appointment;
            Mediator.Notify("GoToExaminationView", "");
        }
    }
}
