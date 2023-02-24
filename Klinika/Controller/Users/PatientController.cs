// File:    PatientController.cs
// Created: Monday, May 11, 2020 2:22:54 PM
// Purpose: Definition of Class PatientController

using Dto;
using Model.Doctor;
using Model.Patient;
using Model.User;
using Service.Users;
using System.Collections.Generic;

namespace Controller.Users
{
    public class PatientController
    {
        private readonly PatientService _patientService;
        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }
        public List<Patient> GetAllPatients()
            => _patientService.GetAllPatients();

        public void SavePatient(RegisterUserDTO patient)
            => _patientService.Save(patient);
        public Doctor GetPrefferedDoctor(Patient patient)
            => _patientService.GetPrefferedDoctor(patient);

        public void SetPrefferedDoctor(Patient patient, Doctor doctor)
            => _patientService.SetPrefferedDoctor(patient, doctor);

        public Patient GetPatient(string jmbg)
            => _patientService.GetPatient(jmbg);

        public Patient RegisterPatient(RegisterUserDTO user)
            => _patientService.Register(user);

        public Patient LoginPatient(string username, string password)
            => _patientService.Login(username, password);

        public void DeletePatient(User user)
            => _patientService.DeleteUser(user);
    }
}