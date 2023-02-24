using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Employees
{
    public class WorkTimeCSVConverter : ICSVConverter<WorkTime>
    {
        private readonly string _delimiter;
        public WorkTimeCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public WorkTime ConvertCSVFormatToEntity(string workTimeCSVFormat)
        {
            string[] tokens = workTimeCSVFormat.Split(_delimiter.ToCharArray());

            return new WorkTime(
                long.Parse(tokens[0]),
                int.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                (AssignedShift)Enum.Parse(typeof(AssignedShift), tokens[3]),
                bool.Parse(tokens[4]),
                new Shift(long.Parse(tokens[5])),
                new Shift(long.Parse(tokens[6]))
                );
        }

        public string ConvertEntityToCSVFormat(WorkTime workTime)
            => string.Join(_delimiter,
                workTime.Id,
                workTime.Cycle,
                workTime.CycleStartDate,
                workTime.CurrShift,
                workTime.FixShift,
                workTime.shift[0].Id,
                workTime.shift[1].Id);
    }
}
