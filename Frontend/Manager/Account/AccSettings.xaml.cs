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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manager.Account
{
    /// <summary>
    /// Interaction logic for AccSettings.xaml
    /// </summary>
    public partial class AccSettings : Window
    {
        public AccSettings()
        {
            InitializeComponent();
            Managerr user = Global.managers[Global.userID];
            txtName.Text = user.Name;
            txtLastName.Text = user.LastName;
            txtUsername.Text = user.Username;
            dateBirth.SelectedDate = DateTime.Parse(user.BirthDate);
            txtAddress.Text = user.Address;
            txtPhone.Text = user.Phone;
            txtEmail.Text = user.Email;
            txtOffice.Text = user.Office;

            if(user.Uri.Length != 0)
            {
                imgUser.Source = new BitmapImage(new Uri(user.Uri));
                txtPath.Text = user.Uri;
            }
            else if (user.Gender == GenderEnum.female)
            {
                imgUser.Source = new BitmapImage(new Uri(@"../Resources/female-nopicture.png", UriKind.Relative));
            }

            txtName.Focus();
        }

        private void btnPassword_Click(object sender, RoutedEventArgs e)
        {
            var wi = new Password();
            wi.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnExplore_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "Izaberite novu sliku";
            fileDialog.Filter = "All suported grphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (.jpg;jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (.png)|*.png";
            if(fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgUser.Source = new BitmapImage(new Uri(fileDialog.FileName));
                txtPath.Text = fileDialog.FileName;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Managerr user = new Managerr();
            user.Name = txtName.Text;
            user.LastName = txtLastName.Text;
            user.Username = txtUsername.Text;
            user.BirthDate = dateBirth.SelectedDate.ToString();
            user.Address = txtAddress.Text;
            user.Email = txtEmail.Text;
            user.Office = txtOffice.Text;
            user.Phone = txtPhone.Text;
            if (txtPath.Text.Trim() != "")
                user.Uri = txtPath.Text;
            else
                user.Uri = "";

            user.Gender = user.Gender;
            user.Password = user.Password;
            user.Jmbg = user.Jmbg;

            Global.managers[Global.userID] = user;
            this.Close();
        }
    }
}
