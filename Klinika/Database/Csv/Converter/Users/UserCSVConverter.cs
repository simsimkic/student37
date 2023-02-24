using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Csv.Converter.Users
{
    public class UserCSVConverter : ICSVConverter<User>
    {
        private readonly string _delimiter;
        public UserCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public User ConvertCSVFormatToEntity(string userCSVFormat)
        {
            string[] tokens = userCSVFormat.Split(_delimiter.ToCharArray());
            List<Role> roles = new List<Role>();

            List<string> roleStrings = tokens[7].Split(';').ToList();
            roleStrings.ForEach(role => roles.Add((Role)Enum.Parse(typeof(Role), role)));
            return new User(
                tokens[0],
                tokens[1],
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                DateTime.Parse(tokens[6]),
                roles,
                new Address(long.Parse(tokens[8]))
                );
        }



        public string ConvertEntityToCSVFormat(User user)
        => string.Join(_delimiter,
            user.Jmbg,
            user.Name,
            user.LastName,
            user.Username,
            user.Email,
            user.Phone,
            user.BirthDate,
            string.Join(";", user.Roles),
            user.Address.Id);
    }
}
