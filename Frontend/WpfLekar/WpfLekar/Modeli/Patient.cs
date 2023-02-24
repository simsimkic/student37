using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLekar.Modeli
{

    public class Patient
    {
        public string name { get; set; }
        public string username { get; set; }
        public string jmbg { get; set; }
        public string lastname { get; set; }
        public string dateOfBirth { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string uriPicture { get; set; }

        public Patient() { }

        public Patient(string name, string username, string jmbg, string lastname, string dateOfBirth, string phone, string email, string address, string uriPicture)
        {
            this.name = name;
            this.username = username;
            this.jmbg = jmbg;
            this.lastname = lastname;
            this.dateOfBirth = dateOfBirth;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.uriPicture = uriPicture;
        }


    }
}
