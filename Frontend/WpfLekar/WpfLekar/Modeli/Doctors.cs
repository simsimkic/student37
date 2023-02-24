using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfLekar.Modeli
{
    public class Doctors: INotifyPropertyChanged
    {

        private string _termini;
        private string _lekari;
        private string _sobesale;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Termini
        {
            get
            {
                return _termini;
            }
            set
            {
                if (value != _termini)
                {
                    _termini = value;
                    OnPropertyChanged("Termini");

                }
            }
        }

        public string Lekari
        {
            get
            {
                return _lekari;
            }
            set
            {
                if (value != _lekari)
                {
                    _lekari = value;
                    OnPropertyChanged("Lekari");

                }
            }
        }


        public string Sobesale
        {
            get
            {
                return _sobesale;
            }
            set
            {
                if (value != _sobesale)
                {
                    _sobesale = value;
                    OnPropertyChanged("SobeSale");

                }
            }
        }




    }
}
