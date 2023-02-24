using Controller.Clinic;
using Manager.Model;
using Model.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using MessageBox = System.Windows.MessageBox;

namespace Manager.Records
{
    /// <summary>
    /// Interaction logic for AllRooms.xaml
    /// </summary>
    public partial class AllRooms : Window
    {
        private readonly RoomController _roomController;

        public static ObservableCollection<RoomTableView> RoomTable { get; set; }
        public AllRooms()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = (App) System.Windows.Application.Current;
            _roomController = app.roomController;

            RoomTable = new ObservableCollection<RoomTableView>();
            foreach (Room r in _roomController.GetAllRooms())
            {
                RoomTable.Add(new RoomTableView { 
                    Id = r.Id, 
                    Func = r.Functionality.FuncName,
                    Dept = r.Department.DepName,
                    IsRenovating = false });
            }
        }

        private void DataGridRow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter || e.Key == Key.Space)
            {
                RoomTableView room = (RoomTableView) roomList.SelectedItem;

                var wi = new RoomInfo(_roomController.GetRoom(room.Id));
                wi.Show();
            }else if(e.Key == Key.Delete)
            {
                RoomTableView room = (RoomTableView)roomList.SelectedItem;

                String message = "Obrisacete prostoriju: " + room.Id + ". Nastaviti?";
                if(MessageBox.Show(message, "Brisanje prostorije", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    RoomTable.Remove(room);
                    _roomController.RemoveRoom(room.Id);
                }
            }
        }
    }
}
