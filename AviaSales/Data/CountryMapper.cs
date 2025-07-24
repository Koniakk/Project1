using AviaSales.Entity;
using AviaSales.Data;
using NewsAPI.Data;

namespace AviaSales.Data
{
    public static class CountryMapper
    {
        public static Country ToEntity(this CountryDTO topic)
        {
            return new Country()
            {
                Id = topic.Id,
                From = topic.From,  
                Where = topic.Where,    
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };
        }

        public static CountryDTO ToDTO(this Country topic)
        {
            return new CountryDTO()
            {
                Id = topic.Id,
                From = topic.From,
                Where = topic.Where,
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };

        }
    }
}
