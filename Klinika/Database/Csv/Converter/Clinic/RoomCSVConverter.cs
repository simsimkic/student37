using Model.Manager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    public class RoomCSVConverter : ICSVConverter<Room>
    {
        private readonly string _delimiter;

        public RoomCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Room ConvertCSVFormatToEntity(string RoomCSVFormat)
        {
            string[] tokens = RoomCSVFormat.Split(_delimiter.ToCharArray());
            List<Equipment> equipment = new List<Equipment>();

            IdListCSVConverter.convertToStringList(tokens[3])
                .ForEach(equipmentId => equipment.Add(new Equipment(equipmentId)));

            return new Room(
                tokens[0],
                int.Parse(tokens[1]),
                new Renovation(long.Parse(tokens[2])),
                equipment,
                new Functionality(long.Parse(tokens[4])),
                new Department(long.Parse(tokens[5])));
        }

        public string ConvertEntityToCSVFormat(Room room)
            => string.Join(_delimiter,
                room.Id,
                room.Floor,
                room.Renovation.Id,
                IdListCSVConverter.convertToCSVFormat(room.Equipment),
                room.Functionality.Id,
                room.Department.Id);
    }
}
