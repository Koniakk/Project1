using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaSales.Entity
{
    public class Ticket : IdentifiableEntity
    {
        private const bool IsNameRequired = true;

        internal class Configuration() : Configuration<Ticket>()
        {
            public override void Configure(EntityTypeBuilder<Ticket> builder)
            {
                builder.Property(author => author.Name)
                    .IsRequired(IsNameRequired);
                builder.HasOne(ticket => ticket.Passenger)
                  .WithMany(passenger => passenger.Tickets)
                  .HasForeignKey(ticket => ticket.PassengerID)
                  .IsRequired(true);

                builder.HasOne(ticket => ticket.CountryFrom)
                  .WithMany(CountryFrom => CountryFrom.From)
                  .HasForeignKey(ticket => ticket.CountryFromID)
                  .IsRequired(true);

                builder.HasOne(ticket => ticket.CountryWhere)
                  .WithMany(CountryWhere => CountryWhere.Where)
                  .HasForeignKey(ticket => ticket.CountryWhereID)
                  .IsRequired(true);

                base.Configure(builder);
            }
        }
        public string? Name { get; set; } = string.Empty;
        public int CountryFromID { get; set; }
        public int CountryWhereID { get; set; }

        public Country? CountryFrom { get; set; }
        public Country? CountryWhere { get; set; }

        public Passenger Passenger { get; set; }
        public int PassengerID { get; set; }
        public int PlaneID { get; set; }

        public int PlaceID { get; set; }


        public DateTime Data { get; set; }

    }
}
