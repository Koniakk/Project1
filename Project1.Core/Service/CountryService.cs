using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core.Service
{
    public class CountryService
    {
        private CountryDataSource _dataSource;
        private List<Country> _countries = new List<Country>();
        public CountryService(CountryDataSource dataSource)
        {
            _dataSource = dataSource;
            _countries = _dataSource.Get();
        }
        
        public List<Country> GetAll()
        {
            return _countries;
        }
    
        public Country Get(int id)
        {
            foreach (Country cinema in _countries)
                if (cinema.ItemId == id)
                    return cinema;
            return null;
        }
        /// <summary>
        /// Добавить новый фильм
        /// </summary>
        /// <param name="country"></param>
        public void Create(Country country)
        {
            _countries.Add(country);
            _dataSource.Write(_countries);
        }
        /// <summary>
        /// Удалить фильм по идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            foreach (Country cinema in _countries)
                if (cinema.ItemId == id)
                {
                    _countries.Remove(cinema);
                    break;
                }
            _dataSource.Write(_countries);
        }
        /// <summary>
        /// Обновить фильм
        /// </summary>
        /// <param name="country"></param>
        public void Update(Country country)
        {
            for (int i = 0; i < _countries.Count; i++)
                if (country.ItemId == _countries[i].ItemId)
                    _countries[i] = country;
            _dataSource.Write(_countries);
        }
    }
}
