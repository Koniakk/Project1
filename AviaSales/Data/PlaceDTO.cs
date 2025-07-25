using AviaSales.Data;
using AviaSales.Entity;

namespace NewsAPI.Data
{
    public record PlaceDTO : IdentifiableEntityDTO
    {
        public string? Name { get; set; } = string.Empty;

    }
}
