using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// Encapsulation of DEBUG rpc api for Geth
    /// Not intended to be used in a standalone instance (instance created by GethRpcProxy class)
    /// based on  
    /// </summary>
    public class GethRpcDebugApi : JsonRpcBase
    {
        internal GethRpcDebugApi(Uri endpoint) 
            : base(endpoint)
        {

        }

      
    }
}
