using Model.Doctor;
using Model.Manager;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.MedicalServices
{
    public class MedicalOperationCSVConverter : ICSVConverter<MedicalOperation>
    {
        private readonly string _delimiter;
        public MedicalOperationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public MedicalOperation ConvertCSVFormatToEntity(string operationCSVFormat)
        {
            string[] tokens = operationCSVFormat.Split(_delimiter.ToCharArray());
            return new MedicalOperation(
                long.Parse(tokens[0]),
                Int32.Parse(tokens[1]),
                Boolean.Parse(tokens[2]),
                new Appointment(tokens[4]),
                new ReferralLetter(long.Parse(tokens[5])),
                new RecoveryRoom(tokens[6]));
        }

        public string ConvertEntityToCSVFormat(MedicalOperation operation)
        => string.Join(_delimiter,
            operation.Id,
            operation.UrgencyLevel,
            operation.Done,
            operation.Appointment.Id,
            operation.ReferralLetter.Id,
            operation.RecoveryRoom.Id);
    }
}
