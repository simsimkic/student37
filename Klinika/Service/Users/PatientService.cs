// File:    PatientService.cs
// Created: Wednesday, May 13, 2020 6:27:36 PM
// Purpose: Definition of Class PatientService

using Dao.Users;
using Dto;
using Klinika.Dao.Users;
using Klinika.Service.Users;
using Model.Doctor;
using Model.Patient;
using Model.User;
using System.Collections.Generic;
using System.Linq;

namespace Service.Users
{
    public class PatientService : AbstractUserService<Patient>
    {
        private readonly IPatientDao _patientDao;
        public PatientService(IPatientDao patientDao, UserValidationService userValidationService, 
            AddressService addressService, IUserDao userDao, IAccountDao accountDao)
            : base(userValidationService, addressService, userDao, accountDao)
        {
            _patientDao = patientDao;
        }
        public List<Patient> GetAllPatients()
            => _patientDao.FindAll().ToList();

        public void SavePatient(Patient patient)
            => _patientDao.Save(patient);

        public Patient GetPatient(string jmbg) => GetUserById(jmbg);

        public Doctor GetPrefferedDoctor(Patient patient)
            => GetPatient(patient.Jmbg).PrefferedDoctor;

        public void SetPrefferedDoctor(Patient patient, Doctor doctor)
        {
            Patient p = GetPatient(patient.Jmbg);
            p.PrefferedDoctor = doctor;
            _patientDao.Save(p);
        }

        protected override Patient RegisterRoleData(RegisterUserDTO user)
        {
            User newUser = new User(user.Jmbg, user.Name, user.LastName, user.Username, user.Email,
                user.Phone, user.BirthDate, user.Roles, user.Address);
            Patient patient = new Patient(newUser, user.Sex, user.MaritalStatus, new List<Question>(), new Doctor(), new MedicalRecord());
            _patientDao.Save(patient);
            return patient;
        }

        protected override Patient GetRoleData(User user)
        {
            Patient data = _patientDao.FindById(user.Jmbg);
            return new Patient(user, data.Sex, data.MaritalStatus, data.Questions, data.PrefferedDoctor, data.MedicalRecord);
        }

        protected override void DeleteFromRoleTable(string jmbg)
            => _patientDao.DeleteById(jmbg);

    }
}