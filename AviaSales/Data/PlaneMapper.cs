using AviaSales.Entity;
using AviaSales.Data;
using NewsAPI.Data;

namespace AviaSales.Data
{
    public static class PlaneMapper
    {
        public static Plane ToEntity(this PlaneDTO topic)
        {
            return new Plane()
            {
                Id = topic.Id,
                Name = topic.Name,
                Company = topic.Company,
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };
        }

        public static PlaneDTO ToDTO(this Plane topic)
        {
            return new PlaneDTO()
            {
                Id = topic.Id,
                Company = topic.Company,
                Name = topic.Name,
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };

        }
    }
}
