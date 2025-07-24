using AviaSales.Entity;

namespace AviaSales.Service
{
    public class PassengerService(DataContext context) : DataEntityService<Passenger>(context)
    {
    }
}
