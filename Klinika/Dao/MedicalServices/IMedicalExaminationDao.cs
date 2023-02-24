// File:    IMedicalExaminationDao.cs
// Created: Sunday, May 24, 2020 9:44:45 PM
// Purpose: Definition of Interface IMedicalExaminationDao

using Dto;
using Model.Doctor;

namespace Dao.MedicalServices
{
   public interface IMedicalExaminationDao : ICRUDDao<MedicalExamination, long>
   {
   
   }
}