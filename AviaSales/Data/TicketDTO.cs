using AviaSales.Entity;

namespace AviaSales.Data
{
    public record TicketDTO : IdentifiableEntityDTO
    {
        public string? Name { get; set; } = string.Empty;
        public int CountryFromID { get; set; }
        public int CountryWhereID { get; set; }
        public int PassengerID { get; set; }

        public DateTime Data { get; set; }
    }
}
