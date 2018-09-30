using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public class OperationResultDecimal
    {

        public OperationResultDecimal()
        {

        }

        public OperationResultDecimal(decimal result, string message) :this()
        {
            this.Result = result;
            this.Message = message;

        }

        public decimal Result { get; set; }
        public string Message { get; set; }
    }
}
