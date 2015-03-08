using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserialization.DTOs
{
    public class DataMerge : AbstractOperation
    {
        public AbstractOperation Source1 { get; set; }
        public AbstractOperation Source2 { get; set; }
        public int MaxResults { get; set; }

        public override Data Execute(string customerId)
        {
            //get data from both sources
            var localData = Source1.Execute(customerId);
            var remoteData = Source2.Execute(customerId);

            //merge data
            //for simplicity, return everything but the intersection
            return new Data
            {
                SomeProducts = localData.SomeProducts.Except(remoteData.SomeProducts)
                                    .Union(remoteData.SomeProducts.Except(localData.SomeProducts))
                                    .Take(MaxResults)
                                    .ToList()
            };
        }
    }
}
