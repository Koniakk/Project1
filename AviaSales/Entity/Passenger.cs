using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AviaSales.Entity
{
    public class Passenger : IdentifiableEntity
    {
        private const bool IsNameRequired = true;

        internal class Configuration() : Configuration<Passenger>()
        {
            public override void Configure(EntityTypeBuilder<Passenger> builder)
            {
                builder.Property(passenger => passenger.Name)
                    .IsRequired(IsNameRequired);

                base.Configure(builder);
            }
        }

        public int Age { get; set; }
        public string? Name { get; set; } = string.Empty;
        public List<Ticket> Tickets { get; set; } = [];


    }
}
