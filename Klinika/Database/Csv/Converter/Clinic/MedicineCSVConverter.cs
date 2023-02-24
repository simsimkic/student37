using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    public class MedicineCSVConverter : ICSVConverter<Medicine>
    {
        private readonly string _delimiter;
        public MedicineCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Medicine ConvertCSVFormatToEntity(string medicineCSVFormat)
        {
            string[] tokens = medicineCSVFormat.Split(_delimiter.ToCharArray());

            List<Ingredient> ing = new List<Ingredient>();
            IdListCSVConverter.convertToStringList(tokens[4])
                .ForEach(ingredient => ing.Add(new Ingredient(long.Parse(ingredient))));

            return new Medicine(
                tokens[0],
                tokens[1],
                int.Parse(tokens[2]),
                (Valid)Enum.Parse(typeof(Valid), tokens[3]),
                ing);
        }

        public string ConvertEntityToCSVFormat(Medicine medicine)
            => string.Join(_delimiter,
                medicine.Tag,
                medicine.Name,
                medicine.Amount,
                medicine.Validation,
                IdListCSVConverter.convertToCSVFormat(medicine.Ingredient));
    }
}
