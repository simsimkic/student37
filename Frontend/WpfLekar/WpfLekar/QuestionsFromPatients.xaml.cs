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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLekar.Modeli;

namespace WpfLekar
{
    /// <summary>
    /// Interaction logic for QuestionsFromPatients.xaml
    /// </summary>
    public partial class QuestionsFromPatients : Page
    {

        public ObservableCollection<QuestionsToAnswer> QnA
        {
            get;
            set;
        }


        public QuestionsFromPatients()
        {
            InitializeComponent();
            this.DataContext = this;
            QnA = new ObservableCollection<QuestionsToAnswer>();
            QnA.Add(new QuestionsToAnswer { Pitanje = "Da li imate laboratoriju?", Pacijent = "Ana Anić" });
            QnA.Add(new QuestionsToAnswer { Pitanje = "Da li je potreban uput za pregled zuba?", Pacijent = "Miloš Tot" });
        }

        private void clkLogo(object sender, RoutedEventArgs e)
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

        private void clkRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

        private void clkLogOut(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void clkBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyAccount.xaml", UriKind.Relative));
        }


        private void clkSend(object sender, RoutedEventArgs e)
        {
            if (dgQuestion.SelectedItems.Count > 0)
            {
                QuestionsToAnswer que = new QuestionsToAnswer();
                que = (QuestionsToAnswer)dgQuestion.SelectedItem;

                QnA.Remove(que);
                MessageBox.Show("Uspešno ste poslali odgovor pacijentu");
            }
            else
            {
                MessageBox.Show("Morate izabrati pitanje na koje želite da odgovorite");
            }
        }

    }
}
