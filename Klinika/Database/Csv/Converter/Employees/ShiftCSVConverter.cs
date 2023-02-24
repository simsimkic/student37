using Model.Manager;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Employees
{
    public class ShiftCSVConverter : ICSVConverter<Shift>
    {
        private readonly string _delimiter;
        public ShiftCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Shift ConvertCSVFormatToEntity(string shiftCSVFormat)
        {
            string[] tokens = shiftCSVFormat.Split(_delimiter.ToCharArray());
            List<DayOfWeek> days = new List<DayOfWeek>();

            List<string> dayStrings = tokens[3].Split(';').ToList();
            dayStrings.ForEach(day => days.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), day)));

            return new Shift(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                days);
        }

        public string ConvertEntityToCSVFormat(Shift shift)
            => string.Join(_delimiter,
                shift.Id,
                shift.Begin,
                shift.End,
                string.Join(";", shift.Days));
    }
}
