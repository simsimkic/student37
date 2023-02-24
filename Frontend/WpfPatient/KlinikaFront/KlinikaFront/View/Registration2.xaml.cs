using KlinikaFront.ViewModel;
using Model.User;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KlinikaFront.View
{
    /// <summary>
    /// Interaction logic for Registration2.xaml
    /// </summary>
    public partial class Registration2 : UserControl
    {
        public Registration2()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext == null) return;
            ((Registration2ViewModel)DataContext).SelectedCountry = (Country)((ComboBox)sender).SelectedItem;
            ((Registration2ViewModel)DataContext).UpdateMunicipalities.Execute(null);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext == null) return;
            ((Registration2ViewModel)DataContext).SelectedMunicipality = (Municipality)((ComboBox)sender).SelectedItem;
            ((Registration2ViewModel)DataContext).UpdateCities.Execute(null);
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext == null) return;
            ((Registration2ViewModel)DataContext).SelectedCity = (City)((ComboBox)sender).SelectedItem;
        }
    }
}
