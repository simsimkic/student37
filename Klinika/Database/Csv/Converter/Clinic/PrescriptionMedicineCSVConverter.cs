using Model.Doctor;
using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    class PrescriptionMedicineCSVConverter : ICSVConverter<PrescriptionMedicine>
    {
        private readonly string _delimiter;

        public PrescriptionMedicineCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }


        public PrescriptionMedicine ConvertCSVFormatToEntity(string prescriptionMedicineCSVFormat)
        {
            string[] tokens = prescriptionMedicineCSVFormat.Split(_delimiter.ToCharArray());
            PrescriptionMedicine prescriptionMedicine = new PrescriptionMedicine();
            prescriptionMedicine.Id = long.Parse(tokens[0]);
            prescriptionMedicine.Quantity = int.Parse(tokens[1]);
            prescriptionMedicine.Medicine.Tag = tokens[2];

            return prescriptionMedicine;
        }

        public string ConvertEntityToCSVFormat(PrescriptionMedicine prescriptionMedicine)
            => string.Join(_delimiter,
                prescriptionMedicine.Id,
                prescriptionMedicine.Quantity,
                prescriptionMedicine.Medicine.Tag);
    }
}
