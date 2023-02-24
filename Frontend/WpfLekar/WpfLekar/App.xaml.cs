using Controller.Clinic;
using Controller.Documents;
using Controller.MedicalServices;
using Controller.Users;
using Dao.Clinic.CSVImpl;
using Dao.Documents.CSVImpl;
using Dao.Employees.CSVImpl;
using Dao.MedicalServices.CSVImpl;
using Dao.Users.CSVImpl;
using Klinika.Controller.Users;
using Klinika.Dao.Users.CSVImpl;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Converter.Documents;
using Klinika.Database.Csv.Converter.Employees;
using Klinika.Database.Csv.Converter.MedicalServices;
using Klinika.Database.Csv.Converter.Users;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Sequencer;
using Klinika.Dto;
using Klinika.Service.Users;
using Model.Doctor;
using Model.Manager;
using Model.Patient;
using Model.Secretary;
using Model.User;
using Service.Clinic;
using Service.Documents;
using Service.Employees;
using Service.MedicalServices;
using Service.Users;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string USER_DB = "..\\DB\\UsersDB.csv";
        private const string DOCTOR_DB = "..\\DB\\DoctorsDB.csv";
        private const string PATIENT_DB = "..\\DB\\PatientsDB.csv";
        private const string ADDRESS_DB = "..\\DB\\AddressesDB.csv";
        private const string MEDICINE_DB = "..\\DB\\MedicinesDB.csv";
        private const string DIAGNNOSIS_DB = "..\\DB\\DiagnosisDB.csv";
        private const string ACCOUNT_DB = "..\\DB\\AccountsDB.csv";
        private const string MUNICIPALITY_DB = "..\\DB\\MunicipalitiesDB.csv";
        private const string CITY_DB = "..\\DB\\CitiesDB.csv";
        private const string COUNTRY_DB = "..\\DB\\CountriesDB.csv";
        private const string TREATMENT_DB = "..\\DB\\TreatmentsDB.csv";
        private const string SPECIALIZATION_DB = "..\\DB\\SpecializationsDB.csv";
        private const string APPOINTMENT_DB = "..\\DB\\AppointmentsDB.csv";
        private const string WORKTIME_DB = "..\\DB\\WorkTimesDB.csv";
        private const string SHIFT_DB = "..\\DB\\ShiftsDB.csv";
        private const string REFERRAL_LETTER_DB = "..\\DB\\ReferralLettersDB.csv";

        private const string CSV_DELIMITER = ",";

        public App() {
            // DAO inicijalizacija
            var userDao = new UserDao(new CSVStream<User>(USER_DB, new UserCSVConverter(CSV_DELIMITER)));
            var doctorDao = new DoctorDao(new CSVStream<Doctor>(DOCTOR_DB, new DoctorCSVConverter(CSV_DELIMITER)));
            var patientDao = new PatientDao(new CSVStream<Patient>(PATIENT_DB, new PatientCSVConverter(CSV_DELIMITER)));
            var accountDao = new AccountDao(new CSVStream<AccountDTO>(ACCOUNT_DB, new AccountCSVConverter(CSV_DELIMITER)));
            var addressDao = new AddressDao(
                new CSVStream<Address>(ADDRESS_DB, new AddressCSVConverter(CSV_DELIMITER)),
                new CSVStream<Municipality>(MUNICIPALITY_DB, new MunicipalityCSVConverter(CSV_DELIMITER)),
                new CSVStream<City>(CITY_DB, new CityCSVConverter(CSV_DELIMITER)),
                new CSVStream<Country>(COUNTRY_DB, new CountryCSVConverter()),
                new LongSequencer()
                );
            var diagnosisDao = new DiagnosisDao(new CSVStream<Diagnosis>(DIAGNNOSIS_DB, new DiagnosisCSVConverter(CSV_DELIMITER)));
            var appointmentDao = new AppointmentDao(new CSVStream<Appointment>(APPOINTMENT_DB, new AppointmentCSVConverter(CSV_DELIMITER)));
            var workTimeDao = new WorkTimeDao(new CSVStream<WorkTime>(WORKTIME_DB, new WorkTimeCSVConverter(CSV_DELIMITER)));
            var shiftDao = new ShiftDao(new CSVStream<Shift>(SHIFT_DB, new ShiftCSVConverter(CSV_DELIMITER)));
            var specializationDao = new SpecializationDao(new CSVStream<Specialization>(SPECIALIZATION_DB, new SpecializationCSVConverter(CSV_DELIMITER)));
            var treatmentDao = new TreatmentDao(new CSVStream<Model.Doctor.Treatment>(TREATMENT_DB, new TreatmentCSVConverter(CSV_DELIMITER)));
            var referralLetterDao = new ReferralLetterDao(new CSVStream<Model.Doctor.ReferralLetter>(REFERRAL_LETTER_DB, new ReferralLetterCSVConverter(CSV_DELIMITER)));
            var medicineDao = new MedicineDao(new CSVStream<Medicine>(MEDICINE_DB, new MedicineCSVConverter(CSV_DELIMITER)));


            // SERVICE inicijalizacija
            var addressService = new AddressService(addressDao);
            var userValidationService = new UserValidationService(accountDao, userDao);
            var doctorService = new DoctorService(doctorDao, userValidationService, addressService, userDao, accountDao);
            var patientService = new PatientService(patientDao, userValidationService, addressService, userDao, accountDao);
            var diagnosisService = new DiagnosisService(diagnosisDao);
            var shiftService = new ShiftService(shiftDao);
            var workTimeService = new WorkTimeService(workTimeDao, shiftService);
            var doctorsAppointmentsService = new DoctorsAppointmentsService(appointmentDao, workTimeService);
            var specializationService = new SpecializationService(specializationDao);
            var treatmentService = new TreatmentService(treatmentDao);
            var referralLetterService = new ReferralLetterService(referralLetterDao);
            var medicineService = new MedicineService(medicineDao);

            // CONTROLLER inicijalizacija
            doctorController = new DoctorController(doctorService);
            patientController = new PatientController(patientService);
            diagnosisController = new DiagnosisController(diagnosisService);
            specializationController = new SpecializationController(specializationService);
            treatmentController = new TreatmentController(treatmentService);
            referralLetterController = new ReferralLetterController(referralLetterService);
            addressController = new AddressController(addressService);
            medicineController = new MedicineController(medicineService);

        }

        public DoctorController doctorController { get; private set; }
        public PatientController patientController { get; private set; }
        public DiagnosisController diagnosisController { get; private set; }
        public SpecializationController specializationController { get; private set; }
        public TreatmentController treatmentController { get; private set; }
        public ReferralLetterController referralLetterController { get; private set; }
        public AddressController addressController { get; private set; }
        public MedicineController medicineController { get; private set; }

    }
}
