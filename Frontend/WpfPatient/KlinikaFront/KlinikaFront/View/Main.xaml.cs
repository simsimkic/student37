using KlinikaFront.Utilities;
using KlinikaFront.ViewModel;
using System.Windows.Controls;

namespace KlinikaFront.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(DataContext != null)
            {
                ((MainViewModel)DataContext).PageHelp = false;
                ((MainViewModel)DataContext).UpdateHelp.Execute(null);
            }
        }
    }
}
