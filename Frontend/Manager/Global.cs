using Manager.Model;
using Model.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public static class Global
    {
        public static Dictionary<string, Managerr> managers = new Dictionary<string, Managerr>();
        public static string userID { get; set; }

        static Global()
        {
            managers = new Dictionary<string, Managerr>();

// Dodavanje upravnika
            managers.Add("goca70", new Managerr("1521145789654", "Gorana", "Jovanovic", "goca70", "admin", "goca70@zdravo.rs",
                "+381/65-555-555", "02.05.1970", "205", GenderEnum.female, "Bulevar Oslobodjenja 15, Novi Sad", ""));
            managers.Add("mare85", new Managerr("1245789541254", "Marko", "Markovic", "mare85", "marko", "mare@zdravo.rs",
                "+381/64-444-444", "01.05.1985", "208", GenderEnum.male, "Kralja Petra 45, Novi Sad", ""));
        }
    }
}
