using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserialization.DTOs
{
    public class LocalDataGetter : AbstractOperation
    {
        public decimal SomeOperationConfigurableParam { get; set; }

        public override Data Execute(string customerId)
        {
            return new Data
            {
                SomeProducts = new List<string>
                {
                    "product1",
                    "product2",
                    "product3"
                }
            };
        }
    }
}
