using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLekar.Modeli
{
    [Serializable]
    public class PatientCard
    {
        public string BloodType { get; set; }
        public bool ChronicPatient { get; set; }
        public bool MedicalCare { get; set; }
        public string Room { get; set; }
        public string Diagnosis { get; set; }
        public string DiagnosisDescription { get; set; }
        public string Medicines { get; set; }
        public string MedicineAdvice { get; set; }
        //public ObservableCollection<ResultOfExamination> ResultsOfExamination { get; set; }

        public PatientCard()
        {
           // ResultsOfExamination = new ObservableCollection<ResultOfExamination>();
        }


    }
}
