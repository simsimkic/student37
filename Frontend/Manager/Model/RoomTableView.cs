using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Manager.Model
{
     public class RoomTableView
    {
        private string _id;
        private string _func;
        private string _dept;
        private bool _isRenovating;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Id
        {
            get => _id;
            set
            {
                if(value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Func
        {
            get => _func;
            set
            {
                if (value != _func)
                {
                    _func = value;
                    OnPropertyChanged("Func");
                }
            }
        }
        public string Dept
        {
            get => _dept;
            set
            {
                if (value != _dept)
                {
                    _dept = value;
                    OnPropertyChanged("Dept");
                }
            }
        }
        public bool IsRenovating
        {
            get => _isRenovating;
            set
            {
                if (value != _isRenovating)
                {
                    _isRenovating = value;
                    OnPropertyChanged("IsRenovating");
                }
            }
        }

    }
}
