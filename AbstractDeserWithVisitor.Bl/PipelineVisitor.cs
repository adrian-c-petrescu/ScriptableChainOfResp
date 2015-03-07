using AbstractDeserWithVisitor.Model.Interface;
using AbstractDeserWithVisitor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserWithVisitor.Bl
{
    public class PipelineVisitor : IPipelineVisitor
    {
        public Data ExecuteRemoteDataGetter(RemoteDataGetter remoteDataGetter, string customerId)
        {
            return new Data
            {
                SomeProducts = new List<string>
                {
                    "product2",
                    "product4"
                }
            };
        }

        public Data ExecuteLocalDataGetter(LocalDataGetter localDataGetter, string customerId)
        {
            return new Data
            {
                SomeProducts = new List<string>
                {
                    "product1",
                    "product2",
                    "product3",
                }
            };
        }

        public Data ExecuteDataMerge(DataMerge dataMerge, string customerId)
        {
            //get data from both sources
            var localData = dataMerge.Source1.Execute(this, customerId);
            var remoteData = dataMerge.Source2.Execute(this, customerId);

            //merge data
            //for simplicity, return everything but the intersection
            return new Data
            {
                SomeProducts = localData.SomeProducts.Except(remoteData.SomeProducts)
                                    .Union(remoteData.SomeProducts.Except(localData.SomeProducts))
                                    .Take(dataMerge.MaxResults)
                                    .ToList()
            };
        }
    }
}
