using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// Encapsulation of TXPOOL rpc api for Geth
    /// Not intended to be used in a standalone instance (instance created by GethRpcProxy class)
    /// based on  https://github.com/ethereum/go-ethereum/wiki/Management-APIs#txpool

    /// based on  
    /// </summary>
    public class GethRpcTxpoolApi : JsonRpcBase
    {
        internal GethRpcTxpoolApi(Uri endpoint) 
            : base(endpoint)
        {

        }

      
    }
}
