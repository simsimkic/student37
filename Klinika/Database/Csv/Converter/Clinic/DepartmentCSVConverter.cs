using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    public class DepartmentCSVConverter : ICSVConverter<Department>
    {
        private readonly string _delimiter;
        public DepartmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Department ConvertCSVFormatToEntity(string departmentCSVFormat)
        {
            string[] tokens = departmentCSVFormat.Split(_delimiter.ToCharArray());

            return new Department(
                long.Parse(tokens[0]),
                tokens[1]);
        }

        public string ConvertEntityToCSVFormat(Department department)
            => string.Join(_delimiter,
                department.Id,
                department.DepName);

    }
}
