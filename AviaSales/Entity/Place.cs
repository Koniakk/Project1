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

                builder.HasOne(place => place.Plane)
                    .WithMany(plane => plane.PlacesInPlane)
                    .HasForeignKey(place => place.PlaneID);

                base.Configure(builder);
            }
        }

        public string? Name { get; set; } = string.Empty;
        public int PlaneID { get; set; }
        public Plane? Plane { get; set; }
        public List<Ticket> Tickets { get; set; } = [];
    }



}
