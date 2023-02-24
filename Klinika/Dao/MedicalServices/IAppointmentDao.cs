// File:    IAppointmentDao.cs
// Created: Sunday, May 24, 2020 11:29:04 PM
// Purpose: Definition of Interface IAppointmentDao

using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Dao.MedicalServices
{
    public interface IAppointmentDao : ICRUDDao<Appointment, long>
    {
        List<Appointment> FindRoomsAppointmentsByWorkTime(Doctor doctor, WorkTime workTime, DateTime date);
        IEnumerable<Appointment> FindByDoctorId(string id);

    }

}