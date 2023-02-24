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
    /// Interaction logic for AllMedicines.xaml
    /// </summary>
    public partial class AllMedicines : Window
    {
        private readonly MedicineController _medicineController;

        public static ObservableCollection<MedicineTableView> MedicineTable { get; set; }
        public AllMedicines()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = (App)System.Windows.Application.Current;
            _medicineController = app.medicineController;

            MedicineTable = new ObservableCollection<MedicineTableView>();
            foreach(Medicine m in _medicineController.GetAllMedicines())
            {
                string status = "";
                if (m.Validation == Valid.denied)
                    status = "Odbijen";
                else if (m.Validation == Valid.processing)
                    status = "Ceka na validaciju";
                else
                    status = "Prihvacen";

                MedicineTable.Add(new MedicineTableView {
                    Tag = m.Tag,
                    Name = m.Name,
                    Amount = m.Amount,
                    Status = status});
            }
        }

        public void DataGridRow_KeyDown(Object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
            {
                MedicineTableView medicine = (MedicineTableView)medicineList.SelectedItem;
                var wi = new MedicineInfo(_medicineController.GetMedicine(medicine.Tag));
                wi.Show();
            }
            else if (e.Key == Key.Delete)
            {
                MedicineTableView medicine = (MedicineTableView)medicineList.SelectedItem;

                String message = "Obrisacete lek: " + medicine.Tag + " iz evidencije. Nastaviti?";
                if (MessageBox.Show(message, "Brisanje leka", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    MedicineTable.Remove(medicine);
                    _medicineController.RemoveMedicine(medicine.Tag);
                }
            }
        }
    }
}
