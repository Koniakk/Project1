using AviaSales.Entity;

namespace AviaSales.Data
{
    public static class TicketMapper
    {
        public static Ticket ToEntity(this TicketDTO topic)
        {
            return new Ticket()
            {
                Id = topic.Id,
                CountryFromID = topic.CountryFromID,
                CountryWhereID = topic.CountryWhereID,
                Name = topic.Name,
                Data = topic.Data,  
                PassengerID = topic.PassengerID,
                PlaneID = topic.PlaneID,
                PlaceID = topic.PlaceID,

                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };
        }

        public static TicketDTO ToDTO(this Ticket topic)
        {
            return new TicketDTO()
            {
                Id = topic.Id,
                CountryFromID = topic.CountryFromID,
                CountryWhereID = topic.CountryWhereID,
                Name = topic.Name,
                Data = topic.Data,
                PassengerID = topic.PassengerID,
                PlaneID = topic.PlaneID,
                PlaceID = topic.PlaceID,    
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };

        }
    }
}
