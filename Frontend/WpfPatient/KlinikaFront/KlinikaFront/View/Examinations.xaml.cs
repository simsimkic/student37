using KlinikaFront.ViewModel;
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
    /// Interaction logic for Examinations.xaml
    /// </summary>
    public partial class Examinations : UserControl
    {
        public Examinations()
        {
            InitializeComponent();
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DataContext != null)
            {
                ((ExaminationsViewModel)DataContext).PageHelp = false;
                ((ExaminationsViewModel)DataContext).UpdateHelp.Execute(null);
            }
        }
    }
}
