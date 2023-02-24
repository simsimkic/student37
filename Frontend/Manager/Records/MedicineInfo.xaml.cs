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
    /// Interaction logic for MedicineInfo.xaml
    /// </summary>
    public partial class MedicineInfo : Window
    {
        private readonly MedicineController _medicineController;
        private readonly IngredientController _ingredientController;

        public Medicine preview;
        public MedicineInfo(Medicine m)
        {
            InitializeComponent();

            var app = (App) Application.Current;
            _medicineController = app.medicineController;
            _ingredientController = app.ingredientController;

            preview = m;
            lblTag.Content = m.Tag;
            lblName.Content = m.Name;
            lblAmount.Content = m.Amount.ToString();

            lblStatus.FontWeight = FontWeights.Bold;
            if(m.Validation == Valid.accepted)
            {
                lblStatus.Content = "Odobren";
                lblStatus.Foreground = Brushes.Green;
            }else if(m.Validation == Valid.processing)
            {
                lblStatus.Content = "Čeka na Validaciju";
                lblStatus.Foreground = Brushes.Orange;
            }else if (m.Validation == Valid.denied)
            {
                lblStatus.Content = "Odbijen";
                lblStatus.Foreground = Brushes.Red;
            }
            foreach (Ingredient i in m.ingredient)
                lboxIngredients.Items.Add(_ingredientController.GetIngredient(i.Id).Name);

            btnClose.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            String message = "Obrisacete lek: " + preview.Tag + " iz evidencije. Nastaviti?";
            if (MessageBox.Show(message, "Brisanje leka", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AllMedicines.MedicineTable.Remove(new MedicineTableView { Tag = preview.Tag, Name = preview.Name, Amount = preview.Amount});
                _medicineController.RemoveMedicine(preview.Tag);
                this.Close();
            }
            
        }
    }
}
