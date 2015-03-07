using AbstractDeserWithVisitor.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserWithVisitor.Model
{
    public abstract class AbstractOperation
    {
        public abstract Data Execute(IPipelineVisitor visitor, string customerId);
    }
}
