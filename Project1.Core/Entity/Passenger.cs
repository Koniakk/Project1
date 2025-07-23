using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project1.Core.Entity
{
    public class Passenger : IIdentifiable
    {
        public static int _id_counter= 0;

        public Passenger(string name, int age)
        {
            ItemId = _id_counter++;
            Name = name;
            Age = age;
        }

        [JsonProperty("ItemId")]
        public int ItemId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }


        public override string ToString()
        {
            return ItemId + "|" + Name  + "|" + Age;
        }

    }
}
