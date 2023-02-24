using Controller.Clinic;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manager.Records
{
    /// <summary>
    /// Interaction logic for AddMedicine.xaml
    /// </summary>
    public partial class AddMedicine : Window
    {
        private readonly MedicineController _medicineController;
        private readonly IngredientController _ingredientController;
        // TODO Izmena odbijenog leka
        public AddMedicine()
        {
            InitializeComponent();

            var app = (App)System.Windows.Application.Current;
            _medicineController = app.medicineController;
            _ingredientController = app.ingredientController;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lviewIngredients.Items.Contains(txtIngredient.Text.Trim()))
                System.Windows.MessageBox.Show("Vec ste dodali sastojak: " + txtIngredient.Text,
                    "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                lviewIngredients.Items.Add(txtIngredient.Text.Trim());
            txtIngredient.Text = "";
            txtIngredient.Focus();
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            Medicine newMedicine = new Medicine();
            newMedicine.Tag = txtID.Text.Trim();
            newMedicine.Name = txtName.Text.Trim();
            newMedicine.Amount = int.Parse(txtAmount.Text.Trim());
            foreach (String i in lviewIngredients.Items)
            {
                Ingredient ing = _ingredientController.AddIngredient(new Ingredient(new long(), i));
                newMedicine.Ingredient.Add(ing);
            }
            newMedicine.Validation = Valid.processing;
            _medicineController.SendForApproval(newMedicine);

            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Medicine medicine = _medicineController.GetMedicine(txtID.Text.Trim());
            _medicineController.AddExistingMedicine(medicine.Tag, int.Parse(txtAmount.Text.Trim()));
            this.Close();
        }

        private void lviewIngredients_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                lviewIngredients.Items.Remove(lviewIngredients.SelectedItem);
            }
        }

        private void txtID_LostFocus(object sender, RoutedEventArgs e)
        {
            Medicine med = _medicineController.GetMedicine(txtID.Text.Trim());
            if (med != null)
            {
                btnSave.IsEnabled = true;
                btnApprove.IsEnabled = false;

                txtName.Text = med.Name;
                txtName.IsEnabled = false;
                foreach (Ingredient i in med.ingredient)
                    lviewIngredients.Items.Add(_ingredientController.GetIngredient(i.Id).Name);
                lviewIngredients.IsEnabled = false;
                txtIngredient.Text = "";
                txtIngredient.IsEnabled = false;
                btnAdd.IsEnabled = false;

                txtAmount.Focus();
            }
            else
            {
                btnSave.IsEnabled = false;
                btnApprove.IsEnabled = true;

                txtName.Text = "";
                txtName.IsEnabled = true;
                lviewIngredients.Items.Clear();
                lviewIngredients.IsEnabled = true;
                txtIngredient.IsEnabled = true;
                btnAdd.IsEnabled = true;

                txtName.Focus();
            }
        }
    }
}
