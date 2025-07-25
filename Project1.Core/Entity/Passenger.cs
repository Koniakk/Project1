﻿using Newtonsoft.Json;
using Project1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project1.Core.Entity
{
    public class Passenger : IdentifiableEntity
    {

        private const bool IsNameRequired = true;
        public static int _id_counter= 0;
        private List<Passenger> articles = [];

        public Passenger(string name, int age)
       {
           ItemId = _id_counter++;
           Name = name;
           Age = age;
       }

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
        public int ItemId { get; set; }


       // public string? Name { get; set; } = string.Empty;
        public List<Ticket> Tickets { get => Tickets; set => articles = value; }         //  public List<Article> Articles { get; set; } = [];





        //[JsonProperty("ItemId")]

        //public string Name { get; set; }



        //public override string ToString()
        //{
        //    return ItemId + "|" + Name  + "|" + Age;
        //}

    }
}
