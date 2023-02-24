using Controller.Clinic;
using Manager.Model;
using Model.Manager;
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

namespace Manager.Records
{
    /// <summary>
    /// Interaction logic for AddEditRoom.xaml
    /// </summary>
    public partial class AddEditRoom : Window, INotifyPropertyChanged
    {
        private readonly RoomController _roomController;
        private readonly EquipmentController _equipmentController;

        private bool _edit;
        public AddEditRoom()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = (App) Application.Current;
            _roomController = app.roomController;
            _equipmentController = app.equipmentController;

            _edit = false;

            lviewAnotherRoom.Items.Clear();
            foreach (Room r in _roomController.GetAllRooms())
                cmbRooms.Items.Add(r.Id);
            cmbRooms.SelectedIndex = 0;

            foreach (Equipment e in _roomController.GetRoom(cmbRooms.SelectedItem.ToString()).Equipment)
                lviewAnotherRoom.Items.Add(e.EquipmentName);
            lviewAnotherRoom.SelectedIndex = 0;
        }

        public AddEditRoom(Room r)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = (App)System.Windows.Application.Current;
            _roomController = app.roomController;
            _equipmentController = app.equipmentController;

            _edit = true;

            txtID.Text = r.Id;
            txtFloor.Text = r.Floor.ToString();
            txtFunc.Text = r.Functionality.FuncName;
            txtDepartmant.Text = r.Department.DepName;

            foreach (Room room in _roomController.GetAllRooms())
                if(room.Id != r.Id)
                    cmbRooms.Items.Add(room.Id);
            cmbRooms.SelectedIndex = 0;

            if(cmbRooms.Items.Count > 0)
                foreach (Equipment e in _roomController.GetRoom(cmbRooms.SelectedItem.ToString()).Equipment)
                    lviewAnotherRoom.Items.Add(e.EquipmentName);
            lviewAnotherRoom.SelectedIndex = 0;

            txtID.IsEnabled = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string _floor;
        public string _id;

        public string Floor
        {
            get => _floor;
            set
            {
                if (value != _floor)
                {
                    _floor = value;
                    OnPropertyChanged("Floor");
                }
            }
        }

        public string Id
        {
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text == "" || txtFloor.Text == "")
            {
                MessageBox.Show("Obavezna polja: Oznaka, sprat !", "Greska");
                return;
            }else if (_edit == false && _roomController.GetRoom(txtID.Text) != null)
            {
                MessageBox.Show("Prostorija vec postoji !", "Greska");
                return;
            }
            
            Room newRoom = new Room();
            newRoom.Id = txtID.Text.Trim();
            newRoom.Floor = int.Parse(txtFloor.Text.Trim());

            if(txtFunc.Text.Trim().Length == 0)
                newRoom.Functionality = new Functionality(1, "Nedefinisana");
            else
                newRoom.Functionality = new Functionality(new long(), txtFunc.Text.Trim());
            if (txtDepartmant.Text.Trim().Length == 0)
                newRoom.Department = new Department(1, "Nedefinisan");
            else
                newRoom.Department = new Department(new long(), txtDepartmant.Text.Trim());

            if (_edit)
            {
                newRoom.Renovation = _roomController.GetRoom(txtID.Text.Trim()).Renovation;
                newRoom.Equipment = _roomController.GetRoom(txtID.Text.Trim()).Equipment;  // TODO Ubaci preko Listboxa
                _roomController.EditRoom(newRoom);
                //Refresh tabele prikaza prostorija
                for (int i = 0; i < AllRooms.RoomTable.Count; i++)
                {
                    if (AllRooms.RoomTable[i].Id.Equals(txtID.Text.Trim()))
                    {
                        AllRooms.RoomTable[i] = new RoomTableView
                        {
                            Id = txtID.Text.Trim(),
                            Func = txtFunc.Text.Trim(),
                            Dept = txtDepartmant.Text.Trim(),
                            IsRenovating = false
                        };
                        break;
                    }
                }
            }
            else
            {
                newRoom.Renovation = new Renovation();
                newRoom.Equipment = new List<Equipment>();      //TODO preko listboxa
                _roomController.AddRoom(newRoom);
            }
            
            this.Close();
        }


        private void cmbRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lviewAnotherRoom.Items.Clear();
            if (cmbRooms.Items.Count > 0)
                foreach (Equipment equip in _roomController.GetRoom(cmbRooms.SelectedItem.ToString()).Equipment)
                    lviewAnotherRoom.Items.Add(equip.EquipmentName);
        }
    }
}
