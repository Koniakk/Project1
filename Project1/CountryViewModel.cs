using Project1.Core;
using Project1.Core.Service;
using Project1App.Core;
using System.Collections.ObjectModel;

namespace Project1
{
   public class CountryViewModel : ObservableObject
    {


        private string _input = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged("Input");
            }
        }

        private ObservableCollection<Country> _countryList = new ObservableCollection<Country>();
        public ObservableCollection<Country> CountryList { get => _countryList; set { _countryList = value; OnPropertyChanged("CountryList"); } }

        private CountryService countryService;

        private Country _selectedCountry;
        public CountryViewModel(CountryService service)
        {
            countryService = service;
            CountryList = new ObservableCollection<Country>(countryService.GetAll());
        }
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
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
                      countryService.Create(
                          new Country(Input)
                          );
                      CountryList = new ObservableCollection<Country>(countryService.GetAll());
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
                      countryService.Delete(
                          SelectedCountry.ItemId
                          );
                      CountryList = new ObservableCollection<Country>(countryService.GetAll());
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
                      SelectedCountry.Title = Input;
                      countryService.Update(
                          SelectedCountry
                          );
                      CountryList = new ObservableCollection<Country>(countryService.GetAll());
                  }));
            }
        }

    }
}
