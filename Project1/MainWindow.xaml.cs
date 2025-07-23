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

        private CountryService countryService = new CountryService(new CountryDataSource());
        private TicketService ticketService = new TicketService(new TicketDataSource());
        private CountryViewModel countryListViewModel;
        private TicketViewModel ticketListViewModel;

        public MainWindow()
        {
            countryListViewModel = new CountryViewModel(countryService);
          //  countryListViewModel = new PassenjerViewModel(passenjerService);
            ticketListViewModel = new TicketViewModel(ticketService, countryService);
            InitializeComponent();
        }
        private void BokingPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TicketListPage(ticketListViewModel);
        }
        private void CountryListPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CountryListPage(countryListViewModel);
        }

        private void PassenjerListPage_Click(object sender, RoutedEventArgs e)
        {
         //   Main.Content = new PassenjerListPage(passenjerListViewModel);
        }


    }
}