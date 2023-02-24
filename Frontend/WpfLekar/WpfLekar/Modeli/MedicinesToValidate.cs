using System.ComponentModel;

namespace WpfLekar.Modeli
{
    public class MedicinesToValidate: INotifyPropertyChanged
    {

        private string _naziv;
        private string _doza;
        private string _dijagnoza;
        private string _nezeljenaDejstva;
        private string _sastojci;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                if (value != _naziv)
                {
                    _naziv = value;
                    OnPropertyChanged("Naziv");

                }
            }
        }

        public string Doza
        {
            get
            {
                return _doza;
            }
            set
            {
                if (value != _doza)
                {
                    _doza = value;
                    OnPropertyChanged("Doza");

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

        public string NezeljenaDejstva
        {
            get
            {
                return _nezeljenaDejstva;
            }
            set
            {
                if (value != _nezeljenaDejstva)
                {
                    _nezeljenaDejstva = value;
                    OnPropertyChanged("NezeljenaDejstva");

                }
            }
        }

        public string Sastojci
        {
            get
            {
                return _sastojci;
            }
            set
            {
                if (value != _sastojci)
                {
                    _sastojci = value;
                    OnPropertyChanged("Sastojci");

                }
            }
        }




    }
}
