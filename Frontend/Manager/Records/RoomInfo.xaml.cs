using Controller.Clinic;
using iTextSharp.text.xml;
using Manager.Model;
using Manager.Other;
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

namespace Manager.Records
{
    /// <summary>
    /// Interaction logic for RoomInfo.xaml
    /// </summary>
    public partial class RoomInfo : Window
    {
        private readonly RoomController _roomController;
        private readonly EquipmentController _equipmentController;

        public static ObservableCollection<EquipmentTableView> roomEquipment { get; set; }
        public RoomInfo(Room r)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = (App) Application.Current;
            _roomController = app.roomController;
            _equipmentController = app.equipmentController;

            lblId.Content = r.Id;
            lblFloor.Content = r.Floor.ToString() + ".";
            lblFunc.Content = r.Functionality.FuncName;
            lblDept.Content = r.Department.DepName;

            roomEquipment = new ObservableCollection<EquipmentTableView>();
            foreach(Equipment eq in _roomController.GetRoom(r.Id).Equipment)
            {
                roomEquipment.Add(new EquipmentTableView
                {
                    Id = eq.EquipmentID,
                    Name = eq.EquipmentName,
                    Type = eq.Type.ToString()
                });
            }

            btnClose.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AddEditRoom(_roomController.GetRoom(lblId.Content.ToString()));
            wi.Show();
        }

        private void btnRenovate_Click(object sender, RoutedEventArgs e)
        {
            var wi = new Renovations(_roomController.GetRoom(lblId.Content.ToString()));
            wi.Show();
        }

        private void DataGridRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
            {
                EquipmentTableView equip = (EquipmentTableView)roomEquipmentList.SelectedItem;
                var wi = new EquipmentInfo(_equipmentController.GetEquipment(equip.Id));
                wi.Show();
            }
            else if (e.Key == Key.Delete)
            {
                EquipmentTableView equip = (EquipmentTableView)roomEquipmentList.SelectedItem;

                String message = "Obrisacete opremu: " + equip.Id + ". Nastaviti?";
                if (MessageBox.Show(message, "Brisanje opreme", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    roomEquipment.Remove(equip);
                    _equipmentController.RemoveEquipment(equip.Id);
                }
            }
        }
    }
}
