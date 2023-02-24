using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.MedicalServices
{
    public class MedicalPrescriptionCSVConverter : ICSVConverter<MedicalPrescription>
    {
        private readonly string _delimiter;

        public MedicalPrescriptionCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public MedicalPrescription ConvertCSVFormatToEntity(string prescriptionCSVFormat)
        {
            string[] tokens = prescriptionCSVFormat.Split(_delimiter.ToCharArray());
            MedicalPrescription prescription = new MedicalPrescription();
            List<PrescriptionMedicine> prescriptionMedicines = new List<PrescriptionMedicine>();
            List<Diagnosis> diagnosis = new List<Diagnosis>();
            prescription.Id = long.Parse(tokens[0]);
            prescription.Note = tokens[1];
            IdListCSVConverter.convertToLongList(tokens[2])
                .ForEach(id => prescriptionMedicines.Add(new PrescriptionMedicine(id)));
            IdListCSVConverter.convertToLongList(tokens[3])
                .ForEach(id => diagnosis.Add(new Diagnosis(id)));

            return prescription;   
        }

        public string ConvertEntityToCSVFormat(MedicalPrescription prescription)
        => string.Join(_delimiter,
            prescription.Id,
            prescription.Note,
            IdListCSVConverter.convertToCSVFormat(prescription.PrescriptionMedicines),
            IdListCSVConverter.convertToCSVFormat(prescription.Diagnosis)
            );
    }
}
