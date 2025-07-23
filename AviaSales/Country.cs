
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.Core.Entity;
using Project1.Entity;




namespace Project1.Core
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
