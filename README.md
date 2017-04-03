# ethereum-for-dotnet
A simple, quick (but not dirty) library to use Ethereum Geth RPC endpoint from .Net

It wraps GETH JsonRPC api in an easy to used C# library. 

I use VisualStudio 2017 to develop it.
Both projects target .Net 4.5.2 but code should be easy to compile for an older version. 


## EthereumWeb3ProtoClient
It is a command line exe to test api. 
Most of test code works with the local ethereum testchain as provided by https://github.com/Nethereum/Nethereum/tree/master/testchain
Actually the best entry point to find samples :)

## EthereumGethRpc
The main project containing the library itself. 
Take care : some API call are still not tested (implementation is just based on Geth RPC signature documentation)
Inline & code comment explicitly mentionned if not tested.

### Usage (C#) : 
```csharp
using EthereumGethRpc;
using EthereumGethRpc.DataModel;
namespace Ethereum4dotnetSample
{
    class Program
    {
        // ...
        async Task GethRpcTestRun()
        {
            Uri web3NodeUrl = new Uri("ip or fdqn of rpc enpoint ");
            GethRpcProxy gethProxy = new GethRpcProxy(web3NodeUrl);
            var protocolVersion=await gethProxy.Eth.GetProtocolVersionAsync();
        }
        // ...
    }
}
```

## Wrapped calls GETH JSON RPC
* **Supported** : Yes if .net wrapping method present, otherwise no
* **Implemented** : Call to rpc method is implemented : yes, partial (see intellisense comment), no
* **Tested** : Call has been tested (see test sample program)

| API | RPC method name | C# method name | Supported | Implemented | Tested |
|-----|-----------------|----------------|-----------|-------------|--------|
| admin | admin_datadir | .Admin.GetDataDirAsync(...) | yes | yes | yes |
| admin | admin_addPeer |  |  |  |  |
| admin | admin_nodeInfo |  |  |  |  |
| admin | admin_peers |  |  |  |  |
| admin | admin_setSolc |  |  |  |  |
| admin | admin_startRPC |  |  |  |  |
| admin | admin_startWS |  |  |  |  |
| admin | admin_stopRPC |  |  |  |  |
| admin | admin_stopWS |  |  |  |  |
| db | db_getString | .DbGetStringAsync.(...) | yes | yes | no |
| db | db_putString | .Db.PutStringSync(...) | yes | yes | no |
| db | db_getHex | .Db.GetHexAsync(...) | yes | yes | no |
| db | db_putHex | .Db.PutHexAsync(...) | yes | yes | no |

| debug | debug_backtraceAt |  |  |  |  |
| debug | debug_blockProfile |  |  |  |  |
| debug | debug_cpuProfile |  |  |  |  |
| debug | debug_dumpBlock |  |  |  |  |
| debug | debug_gcStats |  |  |  |  |
| debug | debug_getBlockRlp |  |  |  |  |
| debug | debug_goTrace |  |  |  |  |
| debug | debug_memStats |  |  |  |  |
| debug | debug_seedHashsign |  |  |  |  |
| debug | debug_setBlockProfileRate |  |  |  |  |
| debug | debug_setHead |  |  |  |  |
| debug | debug_stacks |  |  |  |  |
| debug | debug_startCPUProfile |  |  |  |  |
| debug | debug_startGoTrace |  |  |  |  |
| debug | debug_stopCPUProfile |  |  |  |  |
| debug | debug_stopGoTrace |  |  |  |  |
| debug | debug_traceBlock |  |  |  |  |
| debug | debug_traceBlockByNumber |  |  |  |  |
| debug | debug_traceBlockByHash |  |  |  |  |
| debug | debug_traceBlockFromFile |  |  |  |  |
| debug | debug_traceTransaction |  |  |  |  |
| debug | debug_verbosity |  |  |  |  |
| debug | debug_vmodule |  |  |  |  |
| debug | debug_writeBlockProfile |  |  |  |  |
| debug | debug_writeMemProfile |  |  |  |  |
| eth  TO COMPLETE | eth_ | .Eth.Async(...) | yes | yes | no |
| miner | miner_makeDAG | | no |  |  |
| miner | miner_start | .Miner.StartAsync(...) | yes | yes | yes |
| miner | miner_startAutoDAG | | no |  |  |
| miner | miner_setExtra | | no |  |  |
| miner | miner_setGasPrice | | no |  |  |
| miner | miner_stop | .Miner.StopAsync(...) | yes | yes | yes |
| miner | miner_stopAutoDAG | | no |  |  |
| net | net_version | .Net.GetVersionAsync(...) | yes | yes | yes |
| net | net_listening | .Net.IsListeningAsync(...) | yes | partial | no |
| net | net_peerCount | .Net.GetPeerCountAsync(...) | yes | yes | no |
| personal | personal_listAccounts | .Personal.ListAccountsAsync(...) | yes | yes | yes |
| personal | personal_ecRecover |  | no |  |  |
| personal | personal_importRawKey | | no |  |  |
| personal | personal_newAccount |  | no |  |  |
| personal | personal_lockAccount |  | no |  |  |
| personal | personal_unlockAccount | .Personal.UnlockAccountAsync(...) | yes | yes | yes |
| personal | personal_sendTransaction | .Personal.SendTransactionAsync(...) | yes | partial | yes |
| personal | personal_sign | .Personal.SignAsync(...) | yes | yes | no |
| shh | shh_ | .Shh.Async(...) | yes | yes | no |
| txpool | txpool_content |  | no |  | |
| txpool | txpool_inspect |  | no |  |  |
| txpool | txpool_status |  | no |  |  |
| web3 | web3_ | .Web.Async(...) | yes | yes | no |



