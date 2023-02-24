using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    public class FunctionalityCSVConverter : ICSVConverter<Functionality>
    {
        private readonly string _delimiter;
        public FunctionalityCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Functionality ConvertCSVFormatToEntity(string funcCSVFormat)
        {
            string[] tokens = funcCSVFormat.Split(_delimiter.ToCharArray());

            return new Functionality(
                long.Parse(tokens[0]),
                tokens[1]);
        }

        public string ConvertEntityToCSVFormat(Functionality func)
            => string.Join(_delimiter,
                func.Id,
                func.FuncName);
    }
}
