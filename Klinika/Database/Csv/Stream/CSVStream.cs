using Klinika.Database.Csv.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Database.Csv.Converter.MedicalServices;

namespace Klinika.Database.Csv.Stream
{
    public class CSVStream<E> : ICSVStream<E> where E : class
    {
        private readonly string _path;
        private readonly ICSVConverter<E> _converter;
        

        public CSVStream(string path, ICSVConverter<E> converter)
        {
            _path = path;
            _converter = converter;
            if(!File.Exists(_path))
            {
                FileStream file = File.Create(_path);
                file.Close();
            }
        }

        public void AppendToFile(E entity)
            => File.AppendAllText(_path,
               _converter.ConvertEntityToCSVFormat(entity) + Environment.NewLine);


        public IEnumerable<E> ReadAll()
            => File.ReadAllLines(_path)
                .Select(_converter.ConvertCSVFormatToEntity)
                .ToList();

        public void SaveAll(IEnumerable<E> entities)
            => WriteAllLinesToFile(
                 entities
                 .Select(_converter.ConvertEntityToCSVFormat)
                 .ToList());

        public void WriteAllLinesToFile(IEnumerable<string> content)
            => File.WriteAllLines(_path, content.ToArray());
    }
}
