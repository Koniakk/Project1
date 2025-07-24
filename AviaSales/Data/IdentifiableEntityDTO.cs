namespace AviaSales.Data
{
    public record IdentifiableEntityDTO : EntityDTO
    {
        public int? Id { get; set; }
    }
}
