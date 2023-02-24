using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfLekar.Modeli
{
    public class Services :INotifyPropertyChanged
    {

        private string _usluge;
        private string _cene;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Usluge
        {
            get
            {
                return _usluge;
            }
            set
            {
                if (value != _usluge)
                {
                    _usluge = value;
                    OnPropertyChanged("Usluge");

                }
            }
        }

        public string Cene
        {
            get
            {
                return _cene;
            }
            set
            {
                if (value != _cene)
                {
                    _cene = value;
                    OnPropertyChanged("Cene");

                }
            }
        }




    }
}
