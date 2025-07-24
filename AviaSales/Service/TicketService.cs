using AviaSales.Entity;

namespace AviaSales.Service
{
    public class TicketService(DataContext context) : DataEntityService<Ticket>(context)
    {
    }
}
