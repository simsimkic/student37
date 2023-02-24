using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaFront.DB
{
    class AppointmentsDB
    {
        private AppointmentsDB() { }

        public static AppointmentsDB Instance { get; } = new AppointmentsDB();

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public Appointment Selected { get; set; } = new Appointment();
    }
}
