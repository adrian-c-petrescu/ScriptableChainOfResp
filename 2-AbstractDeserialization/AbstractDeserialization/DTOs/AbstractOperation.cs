using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserialization.DTOs
{
    public abstract class AbstractOperation
    {
        public abstract Data Execute(string customerId);
    }
}
