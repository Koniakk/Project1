using Project1.Core;
using Project1.Core.Service;
using Project1App;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private Project1App.MainViewModel countryListViewModel = new Project1App.MainViewModel(new CountryService(new CountryDataSource()));

        public MainWindow()
        {
            InitializeComponent();
        }
        private void BokingPage_Click(object sender, RoutedEventArgs e)
        {
        }
        private void CountryListPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Project1App.CountryListPage(countryListViewModel);
        }
    }
}