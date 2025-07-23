using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core.Data
{
    public interface IDataSource <T>
    {
        public List<T> Get();


        public void Write(List<T> data);
    }
}
