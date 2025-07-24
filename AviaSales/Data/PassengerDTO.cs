namespace AviaSales.Data
{
    public record PassengerDTO : IdentifiableEntityDTO
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
    }
}
