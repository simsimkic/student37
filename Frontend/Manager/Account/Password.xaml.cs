using Manager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manager.Account
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
            this.DataContext = this;
            pwOld.Focus();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (pwOld.Password.Equals(pwNew.Password))
            {
                MessageBox.Show("Nova lozinka ne sme biti ista kao stara!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }else if (!pwConfirm.Password.Equals(pwNew.Password))
            {
                MessageBox.Show("Nova lozinka se ne poklapa sa potvrdom nove!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Managerr user = Global.managers[Global.userID];
            user.Password = pwNew.Password;

            Global.managers[user.Jmbg] = user;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnSave_Click(sender, e);
            }

        }
    }
}
