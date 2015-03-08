using DiImplementation.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiImplementation.Services
{
    public interface IDataMergeService
    {
        Data MergeData(string customerId);
    }

    public class DataMergeService : IDataMergeService
    {
        private readonly ILocalDataGetter _localDataGetter;
        private readonly IRemoteDataGetter _remoteDataGetter;

        public DataMergeService(ILocalDataGetter localDataGetter, IRemoteDataGetter remoteDataGetter)
        {
            _localDataGetter = localDataGetter;
            _remoteDataGetter = remoteDataGetter;
        }

        public Data MergeData(string customerId)
        {
            //get data from both sources
            var localData = _localDataGetter.RetrieveLocalData(customerId);
            var remoteData = _remoteDataGetter.GetRemoteData(customerId);

            //merge data
            //for simplicity, return everything but the intersection
            return new Data
            {
                SomeProducts = localData.SomeProducts.Except(remoteData.SomeProducts)
                                    .Union(remoteData.SomeProducts.Except(localData.SomeProducts))
                                    .ToList()
            };
        }
    }
}
