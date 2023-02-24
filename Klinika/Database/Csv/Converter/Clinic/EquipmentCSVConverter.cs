using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    public class EquipmentCSVConverter : ICSVConverter<Equipment>
    {
        private readonly string _delimiter;

        public EquipmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Equipment ConvertCSVFormatToEntity(string equipmentCSVFormat)
        {
            string[] tokens = equipmentCSVFormat.Split(_delimiter.ToCharArray());

            return new Equipment(
                tokens[0],
                tokens[1],
                (EquipmentType)Enum.Parse(typeof(EquipmentType), tokens[2]),
                (Status)Enum.Parse(typeof(Status), tokens[3]),
                tokens[4],
                DateTime.Parse(tokens[5]));
        }

        public string ConvertEntityToCSVFormat(Equipment equipment)
            => string.Join(_delimiter,
                equipment.EquipmentID,
                equipment.EquipmentName,
                equipment.Type,
                equipment.EStatus,
                equipment.room.Id,
                equipment.reparation.beginDate.ToString());
    }
}
