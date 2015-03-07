using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserWithVisitor.Model.Interface
{
    public interface IPipelineVisitor
    {
        Data ExecuteDataMerge(DataMerge dataMerge, string customerId);
        Data ExecuteRemoteDataGetter(RemoteDataGetter remoteDataGetter, string customerId);
        Data ExecuteLocalDataGetter(LocalDataGetter localDataGetter, string customerId);
    }
}
