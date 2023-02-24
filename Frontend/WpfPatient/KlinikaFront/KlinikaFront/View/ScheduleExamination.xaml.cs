using KlinikaFront.ViewModel;
using Model.Doctor;
using Model.Secretary;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ScheduleExamination : UserControl
    {
        public ScheduleExamination()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                ((ScheduleExaminationViewModel)DataContext).SelectedDoctor = (Doctor)((ComboBox)sender).SelectedItem;
                ((ScheduleExaminationViewModel)DataContext).DoctorPropertyChanged();
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                ((ScheduleExaminationViewModel)DataContext).SelectedAppointment = (Appointment)((ComboBox)sender).SelectedItem;
            }
        }
    }
}
