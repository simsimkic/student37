using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaFront.User
{
    public sealed class CurrentUser
    {
        private CurrentUser() { }

        public static CurrentUser Instance { get; } = new CurrentUser();

        public Patient Patient { get; set; }
    }
}
