using AviaSales.Entity;

namespace AviaSales.Service
{
    public class CountryService(DataContext context) : DataEntityService<Country>(context)
    {
    }
}
