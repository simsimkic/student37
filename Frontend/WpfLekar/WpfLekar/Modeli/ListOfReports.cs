using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfLekar.Modeli
{
    public class ListOfReports : INotifyPropertyChanged
    {

        private string _datum;
        private string _dijagnoza;
        private string _izvestaj;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Datum
        {
            get
            {
                return _datum;
            }
            set
            {
                if (value != _datum)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");

                }
            }
        }


        public string Dijagnoza
        {
            get
            {
                return _dijagnoza;
            }
            set
            {
                if (value != _dijagnoza)
                {
                    _dijagnoza = value;
                    OnPropertyChanged("Dijagnoza");

                }
            }
        }


        public string Izvestaj
        {
            get
            {
                return _izvestaj;
            }
            set
            {
                if (value != _izvestaj)
                {
                    _izvestaj = value;
                    OnPropertyChanged("Izvestaj");

                }
            }
        }


    }
}
