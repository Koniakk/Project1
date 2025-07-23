
using Project1App.Core;
using System.Collections.ObjectModel;

namespace Aviaseils

{
   public class MainViewModel : ObservableObject
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

        public MainViewModel(ObservableCollection<Country> countryList) => CountryList = countryList;

        private CountryService countryService;

        private Country _selectedCountry;
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
            }
        }

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public MainViewModel(CountryService service)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            countryService = service;
            CountryList = new ObservableCollection<Country>(countryService.GetAll());
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
