// File:    IPrescriptionMedicineDao.cs
// Created: Sunday, May 24, 2020 9:40:55 PM
// Purpose: Definition of Interface IPrescriptionMedicineDao

using Model.Doctor;
using Model.Manager;

namespace Dao.Clinic
{
   public interface IPrescriptionMedicineDao : ICRUDDao<PrescriptionMedicine, long>
   {
   }
}