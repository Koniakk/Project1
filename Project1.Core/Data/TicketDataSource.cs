using Project1.Core.Data;
using Project1.Core.Entity;
using Project1.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core
{
    public class TicketDataSource : IDataSource<Ticket>
    {

        private readonly string path = ".\\ticket_data.json";


        public List<Ticket> Get()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Ticket>>(data) ?? [];
                    Ticket._id_counter = tmp.Count > 0 ? tmp.Select(x => x.ItemId).Max() + 1 : 0;
                    return tmp;
                }

            }
            return [];
        }


        public void Write(List<Ticket> data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {

                writer.WriteLine(DataSerializer.Serialize(data));
            }
        }


    }
}
