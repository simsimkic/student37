using KlinikaFront.ViewModel;
using Model.Doctor;
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
    /// Interaction logic for ExaminationRecommendation.xaml
    /// </summary>
    public partial class ExaminationRecommendation : UserControl
    {
        public ExaminationRecommendation()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                ((ExaminationRecommendationViewModel)DataContext).SelectedDoctor = (Doctor)((ComboBox)sender).SelectedItem;
            }
        }
    }
}
