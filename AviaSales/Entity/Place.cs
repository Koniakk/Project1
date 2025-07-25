using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace AviaSales.Entity
{
    public class Place : IdentifiableEntity
    {
        private const bool IsNameRequired = true;

        internal class Configuration() : Configuration<Place>()
        {
            public override void Configure(EntityTypeBuilder<Place> builder)
            {
                builder.Property(place => place.Name)
                .IsRequired(IsNameRequired);

                base.Configure(builder);
            }
        }

        public string? Name { get; set; } = string.Empty;
        public int PlaneID { get; set; }

    }



}
