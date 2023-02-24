using Controller.Clinic;
using Manager.Model;
using Model.Manager;
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

namespace Manager.Records
{
    /// <summary>
    /// Interaction logic for AddEditEquip.xaml
    /// </summary>
    public partial class AddEditEquip : Window
    {
        private readonly RoomController _roomController;
        private readonly EquipmentController _equipmentController;

        public bool edit;
        public string oldRoom;
        public AddEditEquip()
        {
            InitializeComponent();

            var app = (App)System.Windows.Application.Current;
            _roomController = app.roomController;
            _equipmentController = app.equipmentController;

            edit = false;
            foreach(Room r in _roomController.GetAllRooms())
                cmbRoom.Items.Add(r.Id);
            cmbRoom.SelectedIndex = 0;
        }

        public AddEditEquip(Equipment equip)
        {
            InitializeComponent();

            var app = (App)System.Windows.Application.Current;
            _roomController = app.roomController;
            _equipmentController = app.equipmentController;

            edit = true;
            oldRoom = equip.room.Id;

            txtID.Text = equip.EquipmentID;
            txtName.Text = equip.EquipmentName;
            if (equip.Type == EquipmentType.nonconsumable)
                rbtnNonconsumable.IsChecked = true;
            foreach (Room r in _roomController.GetAllRooms())
                cmbRoom.Items.Add(r.Id);
            cmbRoom.SelectedItem = equip.room.Id;

            txtID.IsEnabled = false;
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Obavezna polja: Naziv, Id !", "Greska");
                return;
            }
            else if (edit == false && _equipmentController.GetEquipment(txtID.Text) != null)
            {
                MessageBox.Show("Oprema sa unetim ID-em vec postoji !", "Greska");
                return;
            }

            Equipment newEquip = new Equipment(txtID.Text.Trim());
            newEquip.EquipmentName = txtName.Text.Trim();
            newEquip.Type = (rbtnConsumable.IsChecked is true) ?  EquipmentType.consumable : EquipmentType.nonconsumable;
            if (cmbRoom.Items.Count != 0)
                newEquip.room = _roomController.GetRoom(cmbRoom.SelectedItem.ToString());
            else
                newEquip.room = new Room();
            

            if (edit)
            {
                newEquip.EStatus = _equipmentController.GetEquipment(txtID.Text).EStatus;
                newEquip.reparation = _equipmentController.GetEquipment(txtID.Text).reparation;
                _equipmentController.EditEquipment(newEquip);
                if(AllEquipment.equipmentTable.Count != 0)
                    for(int i = 0; i < AllEquipment.equipmentTable.Count; i++)
                    {
                        if (AllEquipment.equipmentTable[i].Id.Equals(txtID.Text))
                        {
                            string t = (newEquip.Type == EquipmentType.consumable) ? "Potrosna" : "Nepotrosna";
                            AllEquipment.equipmentTable[i] = new EquipmentTableView { Id = newEquip.EquipmentID,
                                Name = newEquip.EquipmentName, Type = t };
                            break;
                        }
                    }
            }
            else
            {
                newEquip.EStatus = Status.operative;
                newEquip.reparation = new Reparation();
                _equipmentController.AddEquipment(newEquip);
            }

            this.Close();
        }
    }
}
