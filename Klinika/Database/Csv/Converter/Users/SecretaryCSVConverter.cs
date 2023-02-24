using Model.Patient;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class SecretaryCSVConverter : ICSVConverter<Secretary>
    {
        private readonly string _delimiter;
        public SecretaryCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Secretary ConvertCSVFormatToEntity(string secretaryCSVFormat)
        {
            string[] tokens = secretaryCSVFormat.Split(_delimiter.ToCharArray());
            
            return new Secretary(
                tokens[0],
                (Sex)Enum.Parse(typeof(Sex), tokens[1]),
                (MaritalStatus)Enum.Parse(typeof(MaritalStatus), tokens[2]) );
        }

        public string ConvertEntityToCSVFormat(Secretary secretary)
          => string.Join(_delimiter,
                secretary.Jmbg,
                secretary.Sex,
                secretary.MaritalStatus);
        
    }
}
