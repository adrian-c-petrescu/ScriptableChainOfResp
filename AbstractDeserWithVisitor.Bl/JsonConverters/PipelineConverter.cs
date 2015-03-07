using AbstractDeserWithVisitor.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserWithVisitor.Bl.JsonConverters
{
    public class PipelineConverter : JsonCreationConverter<AbstractOperation>
    {
        protected override AbstractOperation Create(Type objectType, JObject jsonObject)
        {
            string typeName = jsonObject["OperType"].Value<string>();

            if (typeName == "DataMerge")
            {
                return new DataMerge();
            }
            if (typeName == "LocalDataGetter")
            {
                return new LocalDataGetter();
            }
            if (typeName == "RemoteDataGetter")
            {
                return new RemoteDataGetter();
            }

            throw new SerializationException(string.Format("Operation type {0} is not supported", typeName));
        }
    }
}
