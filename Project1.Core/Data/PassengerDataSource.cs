using Project1.Core.Entity;
using Project1.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core.Data
{
    public class PassengerDataSource : IDataSource<Passenger>
    {
        private readonly string path = ".\\passenger_data.json";


        public List<Passenger> Get()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Passenger>>(data) ?? [];
                    Passenger._id_counter = tmp.Count > 0 ? tmp.Select(x => x.ItemId).Max() + 1 : 0;
                    return tmp;
                }

            }
            return [];
        }


        public void Write(List<Passenger> data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {

                writer.WriteLine(DataSerializer.Serialize(data));
            }
        }

    }
}
