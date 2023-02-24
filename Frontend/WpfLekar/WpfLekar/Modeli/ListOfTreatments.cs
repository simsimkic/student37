using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfLekar.Modeli
{
    public class ListOfTreatments : INotifyPropertyChanged
    {

        private string _tretman;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Tretman
        {
            get
            {
                return _tretman;
            }
            set
            {
                if (value != _tretman)
                {
                    _tretman = value;
                    OnPropertyChanged("Tretman");

                }
            }
        }

    }
}
