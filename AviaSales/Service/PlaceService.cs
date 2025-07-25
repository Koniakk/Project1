using AviaSales.Entity;

namespace AviaSales.Service
{
    public class PlaceService(DataContext context) : DataEntityService<Place>(context)
    {
    }
}
