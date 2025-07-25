using AviaSales.Data;
using AviaSales.Entity;

namespace NewsAPI.Data
{
    public record CountryDTO : IdentifiableEntityDTO
    {
        public string? Name { get; set; } = string.Empty;
    }
}
