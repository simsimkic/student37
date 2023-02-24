using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Dto
{
    public class AccountDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
