using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Clinic
{
    public class IngredientCSVConverter : ICSVConverter<Ingredient>
    {
        private readonly string _delimiter;
        public IngredientCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Ingredient ConvertCSVFormatToEntity(string ingredientCSVFormat)
        {
            string[] tokens = ingredientCSVFormat.Split(_delimiter.ToCharArray());

            return new Ingredient(
                long.Parse(tokens[0]),
                tokens[1]);
        }

        public string ConvertEntityToCSVFormat(Ingredient ingredient)
            => string.Join(_delimiter,
                ingredient.Id,
                ingredient.Name);
    }
}
