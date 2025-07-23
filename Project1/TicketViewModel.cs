using Project1.Core.Service;
using Project1.Core;
using Project1App.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Core.Entity;

namespace Project1
{
    public class TicketViewModel : ObservableObject
    {

        private string _input = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged(nameof(Input));
            }
        }

    

        private DateTime _inputDate = DateTime.Now;
        public DateTime InputDate
        {
            get => _inputDate;
            set
            {
                _inputDate = value;
                OnPropertyChanged(nameof(InputDate));
            }
        }



        private ObservableCollection<Country> _countryList = new ObservableCollection<Country>();
        public ObservableCollection<Country> CountryList { get => _countryList; set { _countryList = value; OnPropertyChanged("CountryList"); } }

        private CountryService countryService;

        private Country _selectedCountryFrom;
        public Country SelectedCountryFrom
        {
            get => _selectedCountryFrom;
            set
            {
                _selectedCountryFrom = value;
                OnPropertyChanged("SelectedCountryFrom");
            }
        }

        private Country _selectedCountryWhere;
        public Country SelectedCountryWhere
        {
            get => _selectedCountryWhere;
            set
            {
                _selectedCountryWhere = value;
                OnPropertyChanged("SelectedCountryWhere");
            }
        }


        private TicketService ticketService;
        private ObservableCollection<Ticket> ticketList;

        public ObservableCollection<Ticket> TicketList
        {
            get => ticketList;
            set
            {
                ticketList = value;
                OnPropertyChanged(nameof(TicketList));
            }
        }

        public TicketViewModel(TicketService service, CountryService serviceCountry)
        {
            ticketService = service;
            countryService = serviceCountry;
            TicketList = new ObservableCollection<Ticket>(ticketService.GetAll());
            CountryList = new ObservableCollection<Country>(countryService.GetAll());
        }
        private Ticket _selectedTicket;
        public Ticket SelectedTicket
        {
            get => _selectedTicket;
            set
            {
                _selectedTicket = value;
                OnPropertyChanged(nameof(SelectedTicket));
            }
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      ticketService.Create(
                          new Ticket(SelectedCountryFrom, SelectedCountryWhere, InputDate, Input)
                          );
                      TicketList = new ObservableCollection<Ticket>(ticketService.GetAll());
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      ticketService.Delete(
                          SelectedTicket.ItemId
                          );
                      TicketList = new ObservableCollection<Ticket>(ticketService.GetAll());
                  }));
            }
        }

        private RelayCommand editCommand;

        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {
                      SelectedTicket = new Ticket(SelectedCountryFrom, SelectedCountryWhere, InputDate, Input);
                      ticketService.Update(
                                SelectedTicket
                                );
                      TicketList = new ObservableCollection<Ticket>(ticketService.GetAll());
                  }));
            }
        }

    }
}
