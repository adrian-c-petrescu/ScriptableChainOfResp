using DiImplementation.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiImplementation.Services
{
    public interface IRemoteDataGetter
    {
        Data GetRemoteData(string customerId);
    }

    public class RemoteDataGetter : IRemoteDataGetter
    {
        public Data GetRemoteData(string customerId)
        {
            //this would involve calling an external http service and adapt the data into "Data" DTO
            //for simplicity, will hardcode data here

            return new Data
            {
                SomeProducts = new List<string>
                {
                    "product2",
                    "product4"
                }
            };
        }
    }
}
