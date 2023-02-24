using System;
using System.Collections.Generic;
using System.Data;
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

namespace Manager.Records
{
    /// <summary>
    /// Interaction logic for AllEmployees.xaml
    /// </summary>
    public partial class AllEmployees : Window
    {
        public AllEmployees()
        {
            InitializeComponent();
        }

        void fillingEmployeeList()
        {
            DataTable dt = new DataTable();
            DataColumn ime = new DataColumn("Ime", typeof(string));
            DataColumn prezime = new DataColumn("Prezime", typeof(string));
            DataColumn JMBG = new DataColumn("JMBG", typeof(string));
            DataColumn telefon = new DataColumn("Telefon", typeof(string));
            DataColumn zvanje = new DataColumn("Zvanje", typeof(string));
            DataColumn godisnji = new DataColumn("Na godisnjem", typeof(CheckBox));

            dt.Columns.Add(ime);
            dt.Columns.Add(prezime);
            dt.Columns.Add(JMBG);
            dt.Columns.Add(telefon);
            dt.Columns.Add(zvanje);
            dt.Columns.Add(godisnji);

            

            DataRow first = dt.NewRow();
            first[0] = "Marko";
            first[1] = "Markovic";
            first[2] = "0205998522650";
            first[3] = "+38165/22-33-444";
            first[4] = "Lekar opšte prakse";

            dt.Rows.Add(first);

            employeesList.ItemsSource = dt.DefaultView;
        }

        private void employeesList_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingEmployeeList();
        }

    }
}
