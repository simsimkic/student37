using Model.Doctor;
using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Documents
{
    public class QuestionCSVConverter : ICSVConverter<Question>
    {
        private readonly string _delimiter;
        public QuestionCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Question ConvertCSVFormatToEntity(string questionCSVFormat)
        {
            string[] tokens = questionCSVFormat.Split(_delimiter.ToCharArray());
            return new Question(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                tokens[3],
                bool.Parse(tokens[4]),
                new Doctor(tokens[5]));
        }

        public string ConvertEntityToCSVFormat(Question question)
            => string.Join(_delimiter,
                question.Id,
                question.Title,
                question.Content,
                question.Answer,
                question.IsPublic,
                question.Doctor.Jmbg);
    }
}
