using Manager.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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



namespace Manager
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        public Login(string id)
        {
            InitializeComponent();
            txtUsername.Focus();
            txtUsername.Text = Global.managers[id].Username;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Global.managers.ContainsKey(txtUsername.Text))
            {
                if (Global.managers[txtUsername.Text].Password.Equals(pwPass.Password))
                {
                    Global.userID = txtUsername.Text;
                    var wi = new MainWindow();
                    wi.Show();
                    this.Close();
                    return;
                }
                MessageBox.Show("Neispravna lozinka!", "Greska");
                return;
            }
            MessageBox.Show("Korisnik sa unetim korisnickim imenom ne postoji!", "Obavestenje");
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
