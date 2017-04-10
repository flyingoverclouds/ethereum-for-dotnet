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

## GETH JSON RPC Wrapped calls 
* **Supported** : Yes if .net wrapping method present, otherwise no
* **Implemented** : Call to rpc method is implemented : yes, partial (see intellisense comment), no
* **Tested** : Call has been tested (see test sample program)

***API** : admin , db , debug , eth , miner , net , personal , shh , txpool , web3*

| RPC method name | C# method name | Supported | Implemented | Tested |
|-----------------|----------------|-----------|-------------|--------|
| admin_datadir | .Admin.GetDataDirAsync(...) | yes | yes | yes |
| admin_addPeer |  |  |  |  |
| admin_nodeInfo |  |  |  |  |
| admin_peers |  |  |  |  |
| admin_setSolc |  |  |  |  |
| admin_startRPC |  |  |  |  |
| admin_startWS |  |  |  |  |
| admin_stopRPC |  |  |  |  |
| admin_stopWS |  |  |  |  |
| db_getString | .DbGetStringAsync.(...) | yes | yes | no |
| db_putString | .Db.PutStringSync(...) | yes | yes | no |
| db_getHex | .Db.GetHexAsync(...) | yes | yes | no |
| db_putHex | .Db.PutHexAsync(...) | yes | yes | no |
| debug_backtraceAt |  |  |  |  |
| debug_blockProfile |  |  |  |  |
| debug_cpuProfile |  |  |  |  |
| debug_dumpBlock |  |  |  |  |
| debug_gcStats |  |  |  |  |
| debug_getBlockRlp |  |  |  |  |
| debug_goTrace |  |  |  |  |
| debug_memStats |  |  |  |  |
| debug_seedHashsign |  |  |  |  |
| debug_setBlockProfileRate |  |  |  |  |
| debug_setHead |  |  |  |  |
| debug_stacks |  |  |  |  |
| debug_startCPUProfile |  |  |  |  |
| debug_startGoTrace |  |  |  |  |
| debug_stopCPUProfile |  |  |  |  |
| debug_stopGoTrace |  |  |  |  |
| debug_traceBlock |  |  |  |  |
| debug_traceBlockByNumber |  |  |  |  |
| debug_traceBlockByHash |  |  |  |  |
| debug_traceBlockFromFile |  |  |  |  |
| debug_traceTransaction |  |  |  |  |
| debug_verbosity |  |  |  |  |
| debug_vmodule |  |  |  |  |
| debug_writeBlockProfile |  |  |  |  |
| debug_writeMemProfile |  |  |  |  |
| eth_protocolVersion | .Eth.Async(...) | yes |  | no |
| eth_syncing | .Eth.Async(...) | yes |  | no |
| eth_coinbase | .Eth.Async(...) | yes |  | no |
| eth_mining | .Eth.Async(...) | yes |  | no |
| eth_hashrate | .Eth.Async(...) | yes |  | no |
| eth_gasPrice | .Eth.Async(...) | yes |  | no |
| eth_accounts | .Eth.Async(...) | yes |  | no |
| eth_blockNumber | .Eth.Async(...) | yes |  | no |
| eth_getBalance | .Eth.Async(...) | yes |  | no |
| eth_getStorateAt | .Eth.Async(...) | yes |  | no |
| eth_getTransactionCount | .Eth.Async(...) | yes |  | no |
| eth_getBlockTransactionCountByHash | .Eth.Async(...) | yes |  | no |
| eth_getBlockTransactionCountByNumber | .Eth.Async(...) | yes |  | no |
| eth_getUncleCountbyBlockHash | .Eth.Async(...) | yes |  | no |
| eth_getUncleCountByBlockNumber | .Eth.Async(...) | yes |  | no |
| eth_getCode | .Eth.Async(...) | yes |  | no |
| eth_sign | .Eth.Async(...) | yes |  | no |
| eth_sendTransaction | .Eth.Async(...) | yes |  | no |
| eth_sendRawTransaction | .Eth.Async(...) | yes |  | no |
| eth_call | .Eth.Async(...) | yes |  | no |
| eth_estimateGas | .Eth.Async(...) | yes |  | no |
| eth_getBlockByHash | .Eth.Async(...) | yes |  | no |
| eth_getBlockByNumber | .Eth.Async(...) | yes |  | no |
| eth_getTransactionByHash | .Eth.Async(...) | yes |  | no |
| eth_getTransactionByBlockHashAndIndex | .Eth.Async(...) | yes |  | no |
| eth_getTransactionByBlockNuimberAndIndex | .Eth.Async(...) | yes |  | no |
| eth_getCompilers | .Eth.Async(...) | yes |  | no |
| eth_compileLLL | .Eth.Async(...) | yes |  | no |
| eth_compileSolidity | .Eth.Async(...) | yes |  | no |
| eth_compileSerpent | .Eth.Async(...) | yes |  | no |
| eth_newFilter | .Eth.Async(...) | yes |  | no |
| eth_newBlockFilter | .Eth.Async(...) | yes |  | no |
| eth_newPendingTransactionFilter | .Eth.Async(...) | yes |  | no |
| eth_uninstallFilter | .Eth.Async(...) | yes |  | no |
| eth_getFilterChanges | .Eth.Async(...) | yes |  | no |
| eth_getFilterLogs | .Eth.Async(...) | yes |  | no |
| eth_getLogs | .Eth.Async(...) | yes |  | no |
| eth_getWork | .Eth.Async(...) | yes |  | no |
| eth_submitWork | .Eth.Async(...) | yes |  | no |
| eth_submitHashrate | .Eth.Async(...) | yes |  | no |
| miner_makeDAG | | no |  |  |
| miner_start | .Miner.StartAsync(...) | yes | yes | yes |
| miner_startAutoDAG | | no |  |  |
| miner_setExtra | | no |  |  |
| miner_setGasPrice | | no |  |  |
| miner_stop | .Miner.StopAsync(...) | yes | yes | yes |
| miner_stopAutoDAG | | no |  |  |
| net_version | .Net.GetVersionAsync(...) | yes | yes | yes |
| net_listening | .Net.IsListeningAsync(...) | yes | partial | no |
| net_peerCount | .Net.GetPeerCountAsync(...) | yes | yes | no |
| personal_listAccounts | .Personal.ListAccountsAsync(...) | yes | yes | yes |
| personal_ecRecover |  | no |  |  |
| personal_importRawKey | | no |  |  |
| personal_newAccount |  | no |  |  |
| personal_lockAccount |  | no |  |  |
| personal_unlockAccount | .Personal.UnlockAccountAsync(...) | yes | yes | yes |
| personal_sendTransaction | .Personal.SendTransactionAsync(...) | yes | partial | yes |
| personal_sign | .Personal.SignAsync(...) | yes | yes | no |
| shh_version | .Shh.Async(...) | yes | yes | no |
| shh_neWIdentity | .Shh.Async(...) | yes | yes | no |
| shh_hashIdentity | .Shh.Async(...) | yes | yes | no |
| shh_newGroup | .Shh.Async(...) | yes | yes | no |
| shh_addToGroup | .Shh.Async(...) | yes | yes | no |
| shh_newFilter | .Shh.Async(...) | yes | yes | no |
| shh_uninstallFilter | .Shh.Async(...) | yes | yes | no |
| shh_getFilterChanges | .Shh.Async(...) | yes | yes | no |
| shh_getMessages | .Shh.Async(...) | yes | yes | no |
| txpool_content |  | no |  | |
| txpool_inspect |  | no |  |  |
| txpool_status |  | no |  |  |
| web3_clientVersion | .Web.Async(...) | yes | yes | no |
| web3_sha3 | .Web.Async(...) | yes | yes | no |


From [https://github.com/ethereum/go-ethereum/wiki/Management-APIs](https://github.com/ethereum/go-ethereum/wiki/Management-APIs) and [https://github.com/ethereum/wiki/wiki/JSON-RPC](https://github.com/ethereum/wiki/wiki/JSON-RPC)

