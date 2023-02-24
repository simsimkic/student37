using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    public class RenovationCSVConverter : ICSVConverter<Renovation>
    {
        private readonly string _delimiter;

        public RenovationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Renovation ConvertCSVFormatToEntity(string renovationCSVFormat)
        {
            string[] tokens = renovationCSVFormat.Split(_delimiter.ToCharArray());

            return new Renovation(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                (RenovationType)Enum.Parse(typeof(RenovationType), tokens[3]),
                int.Parse(tokens[4])
                );
        }

        public string ConvertEntityToCSVFormat(Renovation renovation)
            => string.Join(_delimiter,
                renovation.Id,
                renovation.BeginDate,
                renovation.DueDate,
                renovation.RenType,
                renovation.Parts);
    }
}
