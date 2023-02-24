using Model.Doctor;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Service.MedicalServices
{
    public interface IAppointmentStrategy
    {
        Appointment GetFreeAppointmentRecommendation(Doctor doctor, List<DateTime> dates);
    }
}
