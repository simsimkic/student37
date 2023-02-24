using KlinikaFront.Utilities;
using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class TherapiesViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _selectTreatments;
        private ICommand _selectPrescriptions;
        private ICommand _selectOperations;
        public List<MedicalTreatment> Treatments { get; private set; }
        public List<Appointment> Operations { get; private set; }
        public List<MedicalPrescription> Prescriptions { get; private set; }

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

        public int TypeSelected { get; private set; } = 0;

        public TherapiesViewModel()
        {
            Treatments = new List<MedicalTreatment>();
            Operations = new List<Appointment>();
            Prescriptions = new List<MedicalPrescription>();
            Treatments.Add(new MedicalTreatment("Previjanje","Nema napomena"));
            Operations.Add(new Appointment(0, DateTime.Now, DateTime.Now.AddDays(7), AppointmentType.operation, new Room(), new Doctor(new Model.User.User("123456", "Marko", "Markovic", "", "", "", DateTime.Now, null, null)), null));
            //Prescriptions.Add(new MedicalPrescription(new List<Medicine>(), "Svaki dan"));

        }

        public ICommand SelectTreatments
        {
            get
            {
                return _selectTreatments ?? (_selectTreatments = new RelayCommand(x =>
                {
                    TypeSelected = 0;
                    OnPropertyChanged("TypeSelected");
                    //Treatments = controller...
                }));
            }
        }

        public ICommand SelectPrescriptions
        {
            get
            {
                return _selectPrescriptions ?? (_selectPrescriptions = new RelayCommand(x =>
                {
                    TypeSelected = 1;
                    OnPropertyChanged("TypeSelected");
                }));
            }
        }

        public ICommand SelectOperations
        {
            get
            {
                return _selectOperations ?? (_selectOperations = new RelayCommand(x =>
                {
                    TypeSelected = 2;
                    OnPropertyChanged("TypeSelected");
                }));
            }
        }
    }
}
