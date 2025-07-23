using Newtonsoft.Json;
using Project1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core.Entity
{
    public class Ticket : IdentifiableEntity
    {
        public static int _id_counter = 0;
        private const bool IsNameRequired = true;


        public Ticket(Country from, Country where, DateTime data, string title_1 = "all avia companies")
        {
            ItemId = _id_counter++;
            Title = title_1;
            CountryFrom = from;
            CountryWhere = where;
            Data = data;
        }



        internal class Configuration() : Configuration<Ticket>()
        {
            public override void Configure(EntityTypeBuilder<Ticket> builder)
            {
                builder.Property(author => author.Name)
                    .IsRequired(IsNameRequired);

                base.Configure(builder);
            }
        }

        [JsonProperty("ItemId")]

        public int ItemId { get; set; }

        public string Title { get; set; }
        public Country CountryFrom { get; set; }
        public Country CountryWhere { get; set; }


        public DateTime Data { get; set; }

        //  string ShownID = 

        public override string ToString()
        {
            return ItemId + "|" + Title + "|" + CountryFrom.Title + "|" + CountryWhere.Title+ "|" + Data;
        }




        public string? Name { get; set; } = string.Empty;
        public List<Ticket> Articles { get; set; } = [];



    }
}
