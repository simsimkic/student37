using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Doctor;
using Model.Secretary;

namespace Klinika.Database.Csv.Converter.Documents
{
    public class ReferralLetterCSVConverter : ICSVConverter<ReferralLetter>
    {
        private readonly string _delimiter;

        public ReferralLetterCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public ReferralLetter ConvertCSVFormatToEntity(string referralLetterCSVFormat)
        {
            string[] tokens = referralLetterCSVFormat.Split(_delimiter.ToCharArray());
            ReferralLetter referralLetter = new ReferralLetter();
            referralLetter.Id = long.Parse(tokens[0]);
            referralLetter.Note = tokens[1];
            referralLetter.MedicalExamination = new MedicalExamination(long.Parse(tokens[2]));
            referralLetter.MedicalOperation = new MedicalOperation(long.Parse(tokens[3]));
            referralLetter.Specialization = new Specialization(long.Parse(tokens[4]));

            return referralLetter;
        }

        public string ConvertEntityToCSVFormat(ReferralLetter referralLetter)
            => string.Join(_delimiter,
                referralLetter.Id,
                referralLetter.Note,
                referralLetter.MedicalExamination.Id,
                referralLetter.MedicalOperation.Id,
                referralLetter.Specialization.Id
                );

        

    }
}
