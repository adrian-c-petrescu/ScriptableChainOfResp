using AbstractDeserWithVisitor.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserWithVisitor.Model
{
    public class DataMerge : AbstractOperation
    {
        public AbstractOperation Source1 { get; set; }
        public AbstractOperation Source2 { get; set; }
        public int MaxResults { get; set; }

        public override Data Execute(IPipelineVisitor visitor, string customerId)
        {
            return visitor.ExecuteDataMerge(this, customerId);
        }
    }
}
