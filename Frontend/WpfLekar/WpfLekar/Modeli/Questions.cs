using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfLekar.Modeli
{
    public class Questions : INotifyPropertyChanged
    {

        private string _pitanje;
        private string _odgovor;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Pitanje
        {
            get
            {
                return _pitanje;
            }
            set
            {
                if (value != _pitanje)
                {
                    _pitanje = value;
                    OnPropertyChanged("Pitanje");

                }
            }
        }

        public string Odgovor
        {
            get
            {
                return _odgovor;
            }
            set
            {
                if (value != _odgovor)
                {
                    _odgovor = value;
                    OnPropertyChanged("Odgovor");

                }
            }
        }




    }
}
