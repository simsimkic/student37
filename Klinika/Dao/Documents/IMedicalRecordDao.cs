// File:    IMedicalRecordDao.cs
// Created: Thursday, May 14, 2020 7:35:38 PM
// Purpose: Definition of Interface IMedicalRecordDao

using Model.Patient;

namespace Dao.Documents
{
   public interface IMedicalRecordDao : Dao.ICRUDDao<MedicalRecord, long>
   {
      HealthCare FindHealthCareByRecord(long id);
      
      void SaveHealthCareToRecord(long id, HealthCare healthCare);
      
      void RemoveHealthCareFromRecord(long id);
   
   }
}