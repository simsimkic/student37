using System.Windows.Controls;
using System.Collections.ObjectModel;
using WpfLekar.Modeli;
using System.Windows;
using System;
using Controller.Clinic;
using System.Collections.Generic;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for ValidationMedicins.xaml
    /// </summary>
    public partial class ValidationMedicins : Page
    {

        private readonly MedicineController _medicineController;
        ObservableCollection<MedicinesToValidate> selectedMeds = new ObservableCollection<MedicinesToValidate>();

        public ObservableCollection<MedicinesToValidate> meds
        {
            get;
            set;
        }

        public ObservableCollection<MedicinesToValidate> SelectedMeds
        {
            get { return selectedMeds; }
            set
            {
                selectedMeds = value;

            }
        }


        public ValidationMedicins()
        {
            InitializeComponent();
            this.DataContext = this;
            meds = new ObservableCollection<MedicinesToValidate>();
            //meds.Add(new MedicinesToValidate { Naziv = "Brufen", Doza = "300mg", Dijagnoza = "Glavobolja", NezeljenaDejstva = "Mučnina", Sastojci = "Ibuprofen"});
            //meds.Add(new MedicinesToValidate { Naziv = "Enalapril", Doza = "10mg", Dijagnoza = "Povišeni protisak", NezeljenaDejstva = "Kašalj", Sastojci = "Enalapril" });
            //meds.Add(new MedicinesToValidate { Naziv = "Bromazepam", Doza = "3mg", Dijagnoza = "Upala bubrega", NezeljenaDejstva = "Pospanost", Sastojci = "Laktoza" });

            // TEST PODACI
            Model.Manager.Medicine medicine = new Model.Manager.Medicine();
            //medicine.Name = "Brufen";
            //medicine.Tag = "BOAOM";
            //medicine.Validation = Model.Manager.Valid.processing;
            //medicine.doctor = new Model.Doctor.Doctor(Global.doc.Jmbg);
            //medicine.Amount = 0;
            //medicine = _medicineController.AddMedicine(medicine);

            MedicinesToValidate newDiag = new MedicinesToValidate()
            {
                Naziv = medicine.Tag
            };
            meds.Add(newDiag);


            try
            {

                var app = (App)Application.Current;
                _medicineController = app.medicineController;

                var medicineCSV = _medicineController.GetAllMedicinesInProccess();
                if (medicineCSV != null)
                {
                    foreach (var med in medicineCSV)
                    {
                        meds.Add(new MedicinesToValidate { Naziv = med.Tag});
                    }
                }
                else
                {
                    MessageBox.Show("Nema lekova!");
                }
            }
            catch (Exception e)
            {

            }


        }

        public void clkLogo(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        public void clkHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void clkService(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Service.xaml", UriKind.Relative));
        }

        private void clkFaq(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Faq.xaml", UriKind.Relative));
        }

        private void clkGallery(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Gallery.xaml", UriKind.Relative));
        }

        private void clkAboutUs(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutUs.xaml", UriKind.Relative));
        }

        private void clkContact(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Contact.xaml", UriKind.Relative));
        }

        private void clkHelp(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }


        private void clkLogOut(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void clkBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyAccount.xaml", UriKind.Relative));
        }

        private void clkSave(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyAccount.xaml", UriKind.Relative));
        }

        private void clkReject(object sender, RoutedEventArgs e)
        {
            if (dataGridMedicine.SelectedItems.Count > 0)
            {
                MedicinesToValidate med = new MedicinesToValidate();
                med = (MedicinesToValidate)dataGridMedicine.SelectedItem;

                meds.Remove(med);
                MessageBox.Show("Uspešno ste odbili neispravan lek!");
            }
            else {
                MessageBox.Show("Morate selektovati lek koji želite da odbijete!");
            }
        }

        private void clkSubmit(object sender, RoutedEventArgs e)
        {
            if (dataGridMedicine.SelectedItems.Count > 0)
            {
                MedicinesToValidate med = new MedicinesToValidate();
                med = (MedicinesToValidate)dataGridMedicine.SelectedItem;

                meds.Remove(med);
                MessageBox.Show("Uspešno ste odobrili ispravan lek!");
            }
            else
            {
                MessageBox.Show("Morate selektovati lek koji želite da odobrite!");
            }

        }

    }
}
