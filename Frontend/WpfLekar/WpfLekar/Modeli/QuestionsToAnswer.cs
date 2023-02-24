using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfLekar.Modeli
{
    public class QuestionsToAnswer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _pitanje;
        private string _pacijent;


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

        public string Pacijent
        {
            get
            {
                return _pacijent;
            }
            set
            {
                if (value != _pacijent)
                {
                    _pacijent = value;
                    OnPropertyChanged("Pacijent");

                }
            }
        }




    }
}
