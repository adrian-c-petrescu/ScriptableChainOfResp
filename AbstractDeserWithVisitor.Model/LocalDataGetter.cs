using AbstractDeserWithVisitor.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserWithVisitor.Model
{
    public class LocalDataGetter : AbstractOperation
    {
        public decimal SomeOperationConfigurableParam { get; set; }

        public override Data Execute(IPipelineVisitor visitor, string customerId)
        {
            return visitor.ExecuteLocalDataGetter(this, customerId);
        }
    }
}
