// File:    IMedicalOperationDao.cs
// Created: Sunday, May 24, 2020 9:50:54 PM
// Purpose: Definition of Interface IMedicalOperationDao

using Model.Secretary;

namespace Dao.MedicalServices
{
   public interface IMedicalOperationDao : ICRUDDao<MedicalOperation, long>
   {
   }
}