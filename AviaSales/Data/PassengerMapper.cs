using AviaSales.Entity;
using AviaSales.Data;
using NewsAPI.Data;

namespace AviaSales.Data
{
    public static class PassengerMapper
    {
        public static Passenger ToEntity(this PassengerDTO topic)
        {
            return new Passenger()
            {
                Id = topic.Id,
                Name = topic.Name,
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };
        }

        public static PassengerDTO ToDTO(this Passenger topic)
        {
            return new PassengerDTO()
            {
                Id = topic.Id,
                Name = topic.Name,
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };

        }
    }
}
