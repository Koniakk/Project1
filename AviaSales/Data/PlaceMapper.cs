using AviaSales.Entity;
using AviaSales.Data;
using NewsAPI.Data;

namespace AviaSales.Data
{
    public static class PlaceMapper
    {
        public static Place ToEntity(this PlaceDTO topic)
        {
            return new Place()
            {
                Id = topic.Id,
                Name = topic.Name,

                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };
        }

        public static PlaceDTO ToDTO(this Place topic)
        {
            return new PlaceDTO()
            {
                Id = topic.Id,
                Name = topic.Name,
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };

        }
    }
}
