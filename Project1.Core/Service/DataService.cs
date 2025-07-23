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


        public class DataEntityService<TSource>(DataContext dataContext) : IDataEntityService<TSource> where TSource : IdentifiableEntity
        {
            internal DataContext _dataContext = dataContext;
            public async Task<IEnumerable<TSource>> Get(DbSet<TSource> dbSet, List<int> ids)
            {
                if (ids.Count <= 0)
                {
                    return await dbSet.ToListAsync();
                }
                return await dbSet
                    .Where(entity =>
                    ids.Contains(
                        entity.Id.GetValueOrDefault()
                        )
                    ).ToListAsync();
            }

            public async Task<bool> Delete(DbSet<TSource> dbSet, List<int> ids)
            {
                if (ids.Count <= 0)
                {
                    return false;
                }
                dbSet.RemoveRange(dbSet.Where(entity =>
                    ids.Contains(
                        entity.Id.GetValueOrDefault()
                        )
                    ));
                return await _dataContext.SaveChangesAsync() > 0;
            }


            public async Task<bool> Set(DbSet<TSource> dbSet, List<TSource> entities)
            {
                if (entities.Count <= 0)
                {
                    return false;
                }
                var newEntities = entities.Where(entity => !entity.Id.HasValue).ToList();
                var oldEntities = entities.Where(entity => entity.Id.HasValue).ToList();

                var oldIds = oldEntities.Select(entity => entity.Id.GetValueOrDefault()).ToList();
                var oldIdsInDb = await dbSet.Where(entity => oldIds.Contains(entity.Id.GetValueOrDefault())).Select(entity => entity.Id.GetValueOrDefault()).ToListAsync();

                var oldIdsNotInDb = oldIds.Except(oldIdsInDb).ToList();

                newEntities.AddRange(oldEntities.Where(entity => oldIdsNotInDb.Contains(entity.Id.GetValueOrDefault())));

                DetachTrackedEntites(oldEntities);

                if (newEntities.Count > 0)
                {
                    dbSet.AddRange(newEntities);
                }
                if (oldEntities.Count > 0)
                {
                    dbSet.UpdateRange(oldEntities);
                }

                return await _dataContext.SaveChangesAsync() > 0;
            }

            private void DetachTrackedEntites(List<TSource> entities)
            {
                var entityIds = entities.Select(entity =>
                        entity.Id.GetValueOrDefault()).ToList();

                foreach (var entityId in entityIds)
                {
                    var entry = _dataContext.ChangeTracker.Entries<TSource>().FirstOrDefault(entry => entry.Entity.Id == entityId);
                    if (entry != null)
                    {
                        _dataContext.Entry(entry.Entity).State = EntityState.Detached;
                    }
                }
            }
        }



        //private IDataSource<T> _dataSource;
        //private List<T> _countries = new List<T>();
        //public DataService(IDataSource<T> dataSource)
        //{
        //    _dataSource = dataSource;
        //    _countries = _dataSource.Get();
        //}

        //public List<T> GetAll()
        //{
        //    return _countries;
        //}

        //public T? Get(int id)
        //{
        //    foreach (T cinema in _countries)
        //        if (cinema.ItemId == id)
        //            return cinema;
        //    return default(T);
        //}
        ///// <summary>
        ///// Добавить новый фильм
        ///// </summary>
        ///// <param name="country"></param>
        //public void Create(T country)
        //{
        //    _countries.Add(country);
        //    _dataSource.Write(_countries);
        //}
        ///// <summary>
        ///// Удалить фильм по идентификатору
        ///// </summary>
        ///// <param name="id"></param>
        //public void Delete(int id)
        //{
        //    foreach (T cinema in _countries)
        //        if (cinema.ItemId == id)
        //        {
        //            _countries.Remove(cinema);
        //            break;
        //        }
        //    _dataSource.Write(_countries);
        //}
        ///// <summary>
        ///// Обновить фильм
        ///// </summary>
        ///// <param name="country"></param>
        //public void Update(T  country)
        //{
        //    for (int i = 0; i < _countries.Count; i++)
        //        if (country.ItemId == _countries[i].ItemId)
        //            _countries[i] = country;
        //    _dataSource.Write(_countries);
        //}
    }
}
