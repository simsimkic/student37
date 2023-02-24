using Controller.Clinic;
using Manager.Model;
using Model.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Manager.Other
{
    /// <summary>
    /// Interaction logic for Renovations.xaml
    /// </summary>
    /// TODO CheckBoxList, Renoviranje
    public partial class Renovations : Window
    {
        private readonly RoomController _roomController;

        public ObservableCollection<CheckedListItem<String>> collToExpand { get; set; }
        public Renovations()
        {
            InitializeComponent();

            var app = (App)Application.Current;
            _roomController = app.roomController;
            collToExpand = new ObservableCollection<CheckedListItem<string>>();

            foreach (Room r in _roomController.GetAllRooms())
                cmbRoom.Items.Add(r.Id);
            cmbRoom.SelectedIndex = 0;

            cmbRoom.Focus();
        }

        public Renovations(Room room)
        {
            InitializeComponent();
            collToExpand = new ObservableCollection<CheckedListItem<string>>();

            cmbRoom.Items.Add(room.Id);
            cmbRoom.SelectedIndex = 0;
            cmbRoom.IsEnabled = false;

            dateStart.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void chkModify_Checked(object sender, RoutedEventArgs e)
        {
            rbtnExpand.IsEnabled = true;
            rbtnSplit.IsEnabled = true;
            if (rbtnSplit.IsChecked == true)
                rbtnSplit_Checked(sender, e);
            else if (rbtnExpand.IsChecked == true)
                rbtnExpand_Checked(sender, e);
        }

        private void chkModify_Unchecked(object sender, RoutedEventArgs e)
        {
            rbtnExpand.IsEnabled = false;
            rbtnSplit.IsEnabled = false;
            rbtnSplit_Unchecked(sender, e);
            rbtnExpand_Unchecked(sender, e);
        }

        private void rbtnSplit_Checked(object sender, RoutedEventArgs e)
        {
            if(chkModify.IsChecked == true)
            {
                lblParts.IsEnabled = true;
                txtParts.IsEnabled = true;
                btnAddmultiple.IsEnabled = true;
            }
        }

        private void rbtnSplit_Unchecked(object sender, RoutedEventArgs e)
        {
            lblParts.IsEnabled = false;
            txtParts.IsEnabled = false;
            btnAddmultiple.IsEnabled = false;
        }

        private void rbtnExpand_Checked(object sender, RoutedEventArgs e)
        {
            if(chkModify.IsChecked == true)
            {
                lblMerge.IsEnabled = true;
                lviewToMerge.IsEnabled = true;
                btnAddRoom.IsEnabled = true;

                foreach (Room r in _roomController.GetAllRooms())
                {
                    if(r.Id != cmbRoom.SelectedItem.ToString())
                    {
                        collToExpand.Add(new CheckedListItem<string>(r.Id, false));
                    }
                }
            }
        }

        private void rbtnExpand_Unchecked(object sender, RoutedEventArgs e)
        {
            lblMerge.IsEnabled = false;
            lviewToMerge.IsEnabled = false;
            btnAddRoom.IsEnabled = false;
        }
    }
}
