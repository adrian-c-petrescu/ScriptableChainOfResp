using AbstractDeserWithVisitor.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserWithVisitor.Model
{
    public class RemoteDataGetter : AbstractOperation
    {
        public string RemoteAddress { get; set; }

        public override Data Execute(IPipelineVisitor visitor, string customerId)
        {
            return visitor.ExecuteRemoteDataGetter(this, customerId);
        }
    }
}
