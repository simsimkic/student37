using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaFront.DB
{
    class DoctorsDB
    {
        private DoctorsDB()
        {
            Doctors.Add(new Doctor(new Model.User.User("12345678387642", "Pera", "Peric", "", "", "", new DateTime(), new List<Model.User.Role>(), new Model.User.Address(0))));
            Doctors.Add(new Doctor(new Model.User.User("12345678987642", "Mika", "Mikic", "", "", "", new DateTime(), new List<Model.User.Role>(), new Model.User.Address(0))));
        }

        public static DoctorsDB Instance { get; } = new DoctorsDB();

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
