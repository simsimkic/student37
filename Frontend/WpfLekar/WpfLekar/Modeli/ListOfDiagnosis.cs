using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfLekar.Modeli
{
    public class ListOfDiagnosis : INotifyPropertyChanged
    {

        private string _dijagnoza;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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

    }
}
