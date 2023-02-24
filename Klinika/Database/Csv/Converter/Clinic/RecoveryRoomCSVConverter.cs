using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    public class RecoveryRoomCSVConverter : ICSVConverter<RecoveryRoom>
    {
        private readonly string _delimiter;

        public RecoveryRoomCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public RecoveryRoom ConvertCSVFormatToEntity(string RRCSVFormat)
        {
            string[] tokens = RRCSVFormat.Split(_delimiter.ToCharArray());

            return new RecoveryRoom(
                new Room(tokens[0]),
                int.Parse(tokens[1]),
                int.Parse(tokens[2])
                );
        }

        public string ConvertEntityToCSVFormat(RecoveryRoom RR)
            => string.Join(_delimiter,
                RR.Id,
                RR.TotalSpots,
                RR.FreeSpots);
    }
}
