using Manager.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            Managerr user = Global.managers[Global.userID];
            lblFullName.Content = user.Name + " " + user.LastName;
            lblJmbg.Content = user.Jmbg;
            lblBirthDate.Content = user.BirthDate;
            lblUserName.Content = user.Username;
            lblAddress.Content = user.Address;
            lblPhone.Content = user.Phone;
            lblEmail.Content = user.Email;
            lblOffice.Content = user.Office;

            if (user.Uri.Length != 0)
            {
                imgUser.Source = new BitmapImage(new Uri(user.Uri));
            }
            else if (user.Gender == GenderEnum.female)
            {
                imgUser.Source = new BitmapImage(new Uri(@"../Resources/female-nopicture.png", UriKind.Relative));
            }

            btnClose.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AccSettings();
            wi.Show();
        }
    }
}
