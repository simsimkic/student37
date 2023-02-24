using Dao.Clinic;
using Dao.Clinic.CSVImpl;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Service.Clinic
{
    public class PrescriptionMedicineService
    {
        public IPrescriptionMedicineDao prescriptionMedicineDao = new PrescriptionMedicineDao();

        public PrescriptionMedicine AddPrescriptionMedicine(PrescriptionMedicine prescriptionMedicine)
            => prescriptionMedicineDao.Save(prescriptionMedicine);

    }
}
