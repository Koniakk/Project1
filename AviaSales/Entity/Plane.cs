using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace AviaSales.Entity
{
    public class Plane : IdentifiableEntity
    {
        private const bool IsNameRequired = true;

        internal class Configuration() : Configuration<Plane>()
        {
            public override void Configure(EntityTypeBuilder<Plane> builder)
            {
                builder.Property(plane => plane.Name)
                .IsRequired(IsNameRequired);

                builder.Property(plane => plane.Company)
               .IsRequired(IsNameRequired);

                base.Configure(builder);
            }
        }
        public string? Name { get; set; } = string.Empty;
        public string? Company { get; set; } = string.Empty;

        public List<Place> PlacesInPlane { get; set; } = [];


    }



}
