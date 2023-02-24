using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLekar.Modeli
{
    public class Medicine
    {
        private string naziv;
        private string doza;
        private string dijagnoza;
        private string nezeljenaDejstva;
        private string sastojci;

        public Medicine(string Naziv, string Doza, string Dijagnoza, string NezeljenaDejstva, string Sastojci) {
            naziv = Naziv;
            doza = Doza;
            dijagnoza = Dijagnoza;
            nezeljenaDejstva = NezeljenaDejstva;
            sastojci = Sastojci;
        }
    }
}
