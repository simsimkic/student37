using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLekar.Modeli
{
    public static class Global
    {
        public static Dictionary<string, string> allDoctors = new Dictionary<string, string>();
        public static Dictionary<string, Doctor> users = new Dictionary<string, Doctor>();
        public static Dictionary<string, Patient> patients = new Dictionary<string, Patient>();
        public static Doctor user { get; set; }
        public static Patient currPatient { get; set; }
        public static List<string> rooms { get; set; }
        public static List<string> allergies { get; set; }
        public static List<Medicine> allMeds { get; set; }
        public static List<string> diagnosis { get; set; }

        public static Model.Doctor.Doctor doc;
        //public static Model.Patient.Patient pat;


        static Global()
        {
            users = new Dictionary<string, Doctor>();
            allDoctors = new Dictionary<string, string>();
            rooms = new List<string>();
            allergies = new List<string>();
            allMeds = new List<Medicine>();
            patients = new Dictionary<string, Patient>();
            diagnosis = new List<string>();

            users.Add("filip", new Doctor("Filip", "filip", "filip", "Filipović", "1234567891234", "25-05-1989", "064/58-97-00", "drfilip@gmail.com", "Šupljikca 55", ""));
            users.Add("pera", new Doctor("Pera", "pera", "pera", "Perić", "9874561239999", "01-02-1982", "061/11-90-86", "drana@gmail.com", "Janka Čmelika 90", ""));
            allDoctors.Add("specijalista", "Vojislav Vojke");
            allDoctors.Add("opšte", "Filip Filipović");
            rooms.Add("200");
            rooms.Add("201");
            rooms.Add("205");
            rooms.Add("306");
            allergies.Add("polen");
            allergies.Add("kupus");
            allMeds.Add(new Medicine("Brufen", "200", "glavobolja", "mučnina", "Ibuprofen"));
            allMeds.Add(new Medicine("Enalapril", "10mg", "Povišeni protisak", "Kašalj", "Enalapril"));
            allMeds.Add(new Medicine("Bromazepam", "3mg", "Upala bubrega", "Pospanost", "Laktoza"));
            patients.Add("branka", new Patient("Branka", "branka", "5236988874125", "Brankić", "09-13-1940", "063/04-99-77", "branka40@gmail.com", "Rumenačka 40", ""));
            diagnosis.Add("Zapaljenje creva");
            diagnosis.Add("Trbušni tifus");
            diagnosis.Add("Upala pluća");
            diagnosis.Add("Trovanje");
            diagnosis.Add("Infekcija creva");
            diagnosis.Add("Dijabetes");
            diagnosis.Add("Deformitet");



        }
        

    }
}
