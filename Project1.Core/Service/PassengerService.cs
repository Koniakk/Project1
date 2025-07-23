using Project1.Core.Data;
using Project1.Core.Entity;

namespace Project1.Core.Service
{
    public class PassengerService : DataService<Passenger>
    {
        private PassengerDataSource _dataSource;
        private List<Passenger> _countries = new List<Passenger>();
        public PassengerService(PassengerDataSource dataSource) : base(dataSource)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            _countries = _dataSource.Get();
        }
    }
}
