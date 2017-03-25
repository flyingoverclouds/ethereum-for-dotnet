using EthereumGethRpc.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGEthRpc
{
    public class JsonRpcException : ApplicationException
    {
        public JsonRpcException() : base ()
        {
        }

        public JsonRpcException(string message) 
            : base(message)
        {
        }
        public JsonRpcException(long code, string message) 
            : base(message)
        {
            this.RpcErrorCode = code;
        }

        public JsonRpcException(JsonRpcResultError resultError) 
            : this(resultError.Code,resultError.Message)
        {
        }

        public long RpcErrorCode { get; private  set; }

    }
}
