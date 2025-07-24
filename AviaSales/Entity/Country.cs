using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace AviaSales.Entity
{
    public class Country : IdentifiableEntity
    {
        private const bool IsNameRequired = true;

        internal class Configuration() : Configuration<Country>()
        {
            public override void Configure(EntityTypeBuilder<Country> builder)
            {
                builder.Property(country => country.Name)
                .IsRequired(IsNameRequired);

                base.Configure(builder);
            }
        }

        public string? Name { get; set; } = string.Empty;
        public List<Ticket> From { get; set; } = [];
        public List<Ticket> Where { get; set; } = [];
    }



}
