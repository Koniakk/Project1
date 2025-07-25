using AviaSales.Data;
using AviaSales.Entity;

namespace NewsAPI.Data
{
    public record PlaneDTO : IdentifiableEntityDTO
    {
        public string? Name { get; set; } = string.Empty;

        public string? Company { get; set; } = string.Empty;
       
    }
}
