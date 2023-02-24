using Klinika.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class AccountCSVConverter : ICSVConverter<AccountDTO>
    {
        private readonly string _delimiter;
        public AccountCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public AccountDTO ConvertCSVFormatToEntity(string accountCSVFormat)
        {
            string[] tokens = accountCSVFormat.Split(_delimiter.ToCharArray());
            return new AccountDTO(tokens[0], tokens[1]);
        }

        public string ConvertEntityToCSVFormat(AccountDTO accountDTO)
            => string.Join(_delimiter,
                accountDTO.Username,
                accountDTO.Password);
    }
}
