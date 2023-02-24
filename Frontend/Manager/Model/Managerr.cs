using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Model
{
    public class Managerr
    {
        public string Jmbg { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string Office { get; set; }
        public GenderEnum Gender { get; set; }
        public string Address { get; set; }
        public string Uri { get; set; }
        

        public Managerr()
        {

        }
        public Managerr(string jmbg, string name, string lastName, string username, string password, string email,
            string phone, string birthdate, string office, GenderEnum gender, string address, string uri)
        {
            Jmbg = jmbg;
            Name = name;
            LastName = lastName;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            BirthDate = birthdate;
            Office = office;
            Gender = gender;
            Address = address;
            Uri = uri;
        }
    }
}
