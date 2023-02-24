using Klinika.Service.Clinic;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Controller.Clinic
{
    public class PrescriptionMedicineController
    {
        public PrescriptionMedicineService prescriptionMedicineService = new PrescriptionMedicineService();

        public PrescriptionMedicine AddPrescriptionMedicine(PrescriptionMedicine prescriptionMedicine)
            => prescriptionMedicineService.AddPrescriptionMedicine(prescriptionMedicine);

    }
}
