using Project1.Core.Data;
using Project1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core.Service
{
    public class DataService <T> where T : IIdentifiable
    {
        private IDataSource<T> _dataSource;
        private List<T> _countries = new List<T>();
        public DataService(IDataSource<T> dataSource)
        {
            _dataSource = dataSource;
            _countries = _dataSource.Get();
        }

        public List<T> GetAll()
        {
            return _countries;
        }

        public T? Get(int id)
        {
            foreach (T cinema in _countries)
                if (cinema.ItemId == id)
                    return cinema;
            return default(T);
        }
        /// <summary>
        /// Добавить новый фильм
        /// </summary>
        /// <param name="country"></param>
        public void Create(T country)
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
            foreach (T cinema in _countries)
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
        public void Update(T  country)
        {
            for (int i = 0; i < _countries.Count; i++)
                if (country.ItemId == _countries[i].ItemId)
                    _countries[i] = country;
            _dataSource.Write(_countries);
        }
    }
}
