using Controller.Clinic;
using Manager.Model;
using Manager.Other;
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
    /// Interaction logic for EquipmentInfo.xaml
    /// </summary>
    public partial class EquipmentInfo : Window
    {
        private readonly EquipmentController _equipmentController;
        public EquipmentInfo(Equipment equip)
        {
            InitializeComponent();

            var app = (App)System.Windows.Application.Current;
            _equipmentController = app.equipmentController;

            btnMove.Focus();
            lblId.Content = equip.EquipmentID;
            lblName.Content = equip.EquipmentName;
            lblType.Content = (equip.Type == EquipmentType.consumable) ? "Potrosna" : "Nepotrosna";
            lblLocation.Content = equip.room.Id;
            if(equip.EStatus == Status.operative)
                chkStatus.IsChecked = true;

            if(equip.Type == EquipmentType.consumable)
            {
                btnRepair.Visibility = Visibility.Hidden;
                chkStatus.Visibility = Visibility.Hidden;
            }
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var wi = new AddEditEquip(_equipmentController.GetEquipment(lblId.Content.ToString()));
            wi.Show();
        }

        private void btnRepair_Click(object sender, RoutedEventArgs e)
        {
            var wi = new Reparations();
            wi.Show();
        }
    }
}
