using Project1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core.Service
{
    public class TicketService : DataService<Ticket>
    {

        private TicketDataSource _ticketDataSource;
        private List<Ticket> ticketss = new List<Ticket>();
        public TicketService(TicketDataSource dataSource) : base(dataSource)
        {
            _ticketDataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            ticketss = _ticketDataSource.Get();
        }

        //public List<Ticket> GetAll()
        //{
        //    return ticketss;
        //}

        //public Ticket Get(int id)
        //{
        //    foreach (Ticket cinema in ticketss)
        //        if (cinema.ItemId == id)
        //            return cinema;
        //    return null;
        //}
        ///// <summary>
        ///// Добавить новый фильм
        ///// </summary>
        ///// <param name="country"></param>
        //public void Create(Ticket country)
        //{
        //    ticketss.Add(country);
        //    _ticketDataSource.Write(ticketss);
        //}
        ///// <summary>
        ///// Удалить фильм по идентификатору
        ///// </summary>
        ///// <param name="id"></param>
        //public void Delete(int id)
        //{
        //    foreach (Ticket cinema in ticketss)
        //        if (cinema.ItemId == id)
        //        {
        //            ticketss.Remove(cinema);
        //            break;
        //        }
        //    _ticketDataSource.Write(ticketss);
        //}
        ///// <summary>
        ///// Обновить фильм
        ///// </summary>
        ///// <param name="country"></param>
        //public void Update(Ticket country)
        //{
        //    for (int i = 0; i < ticketss.Count; i++)
        //        if (country.ItemId == ticketss[i].ItemId)
        //            ticketss[i] = country;
        //    _ticketDataSource.Write(ticketss);
        //}


    }
}
