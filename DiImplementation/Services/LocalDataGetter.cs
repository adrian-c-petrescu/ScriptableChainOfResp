using DiImplementation.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiImplementation.Services
{
    public interface ILocalDataGetter
    {
        Data RetrieveLocalData(string customerId);
    }

    public class LocalDataGetter : ILocalDataGetter
    {
        public Data RetrieveLocalData(string customerId)
        {
            //should call into a repository, to get data belonging to this system
            //but will hardcode something for simplicity
            return new Data
            {
                SomeProducts = new List<string>
                {
                    "product1",
                    "product2",
                    "product3"
                }
            };
        }
    }
}
