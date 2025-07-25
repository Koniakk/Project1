using AviaSales.Entity;

namespace AviaSales.Service
{
    public class PlaneService(DataContext context) : DataEntityService<Plane>(context)
    {
    }
}
