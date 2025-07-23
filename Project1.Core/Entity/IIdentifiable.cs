using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core.Entity
{
    public interface IIdentifiable
    {
        private static int _id_counter { get; set; } = 0;
        public int ItemId { get; set; }
    }
}
