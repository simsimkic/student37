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

namespace Manager.Records
{
    /// <summary>
    /// Interaction logic for AllEquipment.xaml
    /// </summary>
    public partial class AllEquipment : Window
    {
        private readonly EquipmentController _equipmentController;
        public static ObservableCollection<EquipmentTableView> equipmentTable { get; set; }
        public AllEquipment()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = (App)System.Windows.Application.Current;
            _equipmentController = app.equipmentController;

            equipmentTable = new ObservableCollection<EquipmentTableView>();
            foreach (Equipment e in _equipmentController.GetAllEquipment())
            {
                string t = (e.Type == EquipmentType.consumable) ? "Potrosna" : "Nepotrosna";
                equipmentTable.Add(new EquipmentTableView { Id = e.EquipmentID, Name = e.EquipmentName, Type = t});
            }
                
        }

        private void DataGridRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
            {
                EquipmentTableView equip = (EquipmentTableView)equipmentList.SelectedItem;

                var wi = new EquipmentInfo(_equipmentController.GetEquipment(equip.Id));
                wi.Show();
            }
            else if (e.Key == Key.Delete)
            {
                EquipmentTableView equip = (EquipmentTableView)equipmentList.SelectedItem;

                String message = "Obrisacete opremu: " + equip.Id + ". Nastaviti?";
                if (MessageBox.Show(message, "Brisanje opreme", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    equipmentTable.Remove(equip);
                    _equipmentController.RemoveEquipment(equip.Id);
                }
            }
        }
    }
}
