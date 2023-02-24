// File:    IDiagnosisDao.cs
// Created: Wednesday, May 27, 2020 3:24:21 PM
// Purpose: Definition of Interface IDiagnosisDao


using Model.Doctor;

namespace Dao.Documents
{
   public interface IDiagnosisDao : Dao.ICRUDDao<Diagnosis, long>
   {
   }
}