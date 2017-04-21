# ethereum-for-dotnet
A simple, quick (but not dirty) library to use Ethereum Geth RPC endpoint from .Net

It wraps GETH JsonRPC api in an easy to use C# library. 

I use VisualStudio 2017 to develop it.
Both projects target .Net 4.5.2 but code should be easy to compile for an older version or for dotnetcore (specific project will come)


## EthereumWeb3ProtoClient
It is a command line exe to test api. 
Most of test code works with the local ethereum testchain as provided by https://github.com/Nethereum/Nethereum/tree/master/testchain
Actually the best entry point to find samples :)

## EthereumGethRpc
The main project containing the library itself. 
Take care : some API call are still not tested (implementation is just based on Geth RPC call signature documentation)
Inline & code comment explicitly mentionned if not tested, or see above table.

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
* **Implemented** : Call to rpc method is implemented : yes, partial (see intellisense comment), no (=throw NotImplementException)
* **Tested** : Call has been tested (see test sample program)

***Supported API** : admin , db , debug , eth , miner , net , personal , shh , txpool , web3* 

***Columns** : S=Supported, I=Implemened, T=Tested*

| RPC method name | C# method name | S | I | T |
|-----------------|----------------|-----------|-------------|--------|
| admin_datadir | .Admin.GetDataDirAsync(...) | yes | yes | yes |
| admin_addPeer | .Admin.AddPeedAsync(...) | yes | yes | no |
| admin_nodeInfo | .Admin.GetNodeInfoAsync(...) | yes | no | no |
| admin_peers | .Admin.GetPeersAsync(...) | yes | no | yes |
| admin_setSolc | .Admin.SetSolcAsync(...) | yes | yes | no |
| admin_startRPC |.Admin.StartRpcAsync(...)  | yes | yes | no |
| admin_startWS | .Admin.StartWsAsync(...) | yes | yes | no |
| admin_stopRPC | .Admin.StopRpcAsync(...) | yes | yes | no |
| admin_stopWS | .Admin.StopWsAsync(...) | yes | yes | no |
| db_getString | .DbGetStringAsync.(...) | yes | yes | no |
| db_putString | .Db.PutStringSync(...) | yes | yes | no |
| db_getHex | .Db.GetHexAsync(...) | yes | yes | no |
| db_putHex | .Db.PutHexAsync(...) | yes | yes | no |
| debug_backtraceAt | .Debug. | no |  |  |
| debug_blockProfile | .Debug. | no |  |  |
| debug_cpuProfile | .Debug. | no |  |  |
| debug_dumpBlock | .Debug. | no |  |  |
| debug_gcStats | .Debug. | no |  |  |
| debug_getBlockRlp | .Debug. | no |  |  |
| debug_goTrace | .Debug. | no |  |  |
| debug_memStats | .Debug. | no |  |  |
| debug_seedHashsign |.Debug. | no |  |  |
| debug_setBlockProfileRate | .Debug. | no |  |  |
| debug_setHead | .Debug. | no |  |  |
| debug_stacks | .Debug. | no |  |  |
| debug_startCPUProfile | .Debug. | no |  |  |
| debug_startGoTrace | .Debug. | no |  |  |
| debug_stopCPUProfile | .Debug. | no |  |  |
| debug_stopGoTrace | .Debug. | no |  |  |
| debug_traceBlock | .Debug. | no |  |  |
| debug_traceBlockByNumber |.Debug.  | no |  |  |
| debug_traceBlockByHash | .Debug. | no |  |  |
| debug_traceBlockFromFile | .Debug. | no |  |   |
| debug_traceTransaction | .Debug. | no |  |  |
| debug_verbosity |.Debug.  | no |  |  |
| debug_vmodule | .Debug. | no |  |  |
| debug_writeBlockProfile | .Debug. | no |  |  |
| debug_writeMemProfile |.Debug.  | no |  |  |
| eth_protocolVersion | .Eth.GetProtocolVersionAsync(...) | yes | yes | yes |
| eth_syncing | .Eth.SyncingStatusAsync(...) | yes | yes | no |
| eth_coinbase | .Eth.GetCoinbaseAddressAsync(...) | yes | yes | yes |
| eth_mining | .Eth.IsMiningAsync(...) | yes | yes | yes |
| eth_hashrate | .Eth.GetHashRateAsync(...) | yes | yes | yes |
| eth_gasPrice | .Eth.GetGasPriceAsync(...) | yes | yes | yes |
| eth_accounts | .Eth.GetAccountsAsync(...) | yes | yes | yes |
| eth_blockNumber | .Eth.GetBlockNumberAsync(...) | yes | yes | yes |
| eth_getBalance | .Eth.GetBalanceAsync(...) | yes | yes | yes |
| eth_getStorateAt | .Eth.GetStorageAtAsync(...) | yes | yes | no |
| eth_getTransactionCount | .Eth.GetTransactionCountAsync(...) | yes | yes | no |
| eth_getBlockTransactionCountByHash | .Eth.GetBlockTransactionCountByHashAsync(...) | yes | yes | no |
| eth_getBlockTransactionCountByNumber | .Eth.GetBlockTransactionCountByNumberAsync(...) | yes | yes | no |
| eth_getUncleCountbyBlockHash | .Eth.GetUncleCountByBlockHashAsync(...) | yes | yes | no |
| eth_getUncleCountByBlockNumber | .Eth.GetUncleCountByBlockNumberAsync(...) | yes | partial | no |
| eth_getCode | .Eth.GetCodeAsync(...) | yes | yes | no |
| eth_sign | .Eth.SignAsync(...) | yes | yes | no |
| eth_sendTransaction | .Eth.SendTransactionAsync(...) | yes | yes | yes |
| eth_getTransactionReceipt | .Eth.GetTransactionReceiptAsync(...) | yes | yes | yes |
| eth_sendRawTransaction | .Eth.SendRawTransactionAsync(...) | yes | yes | no |
| eth_call | .Eth.CallAsync(...) | yes | yes | no |
| eth_estimateGas | .Eth.EstimateGasAsync(...) | yes | yes | no |
| eth_getBlockByHash | .Eth.GetBlockByHashAsync(...) | yes | partial | no |
| eth_getBlockByNumber | .Eth.GetBlockByNumberAsync(...) | yes | partial | no |
| eth_getTransactionByHash | .Eth.GetTransactionByHashAsync(...) | yes | yes | yes |
| eth_getTransactionByBlockHashAndIndex | .Eth.GetTransactionByBlockHashAndIndexAsync(...) | yes | yes | yes |
| eth_getTransactionByBlockNumberAndIndex | .Eth.GetTransactionByBlockNumberAndIndexAsync(...) | yes | yes | no |
| eth_getUncleByBlockHashAndIndex | .Eth.GetUncleByBlockHashAndIndexAsync(...) | yes | partial | no |
| eth_getUncleByBlockNumberAndIndex | .Eth.GetUncleByBlockNumberAndIndexAsync(...) | yes | partial | no |
| eth_getCompilers | .Eth.GetCompilersAsync(...) | yes | yes | yes |
| eth_compileLLL | .Eth.CompileLLLAsync(...) | yes | yes | no |
| eth_compileSolidity | .Eth.CompileSolidityAsync(...) | yes | yes | yes |
| eth_compileSerpent | .Eth.CompileSerpentAsync(...) | yes | yes | no |
| eth_newFilter | .Eth.NewFilterAsync(...) | yes | no | no |
| eth_newBlockFilter | .Eth.NewBlockFilterAsync(...) | yes | yes | yes |
| eth_newPendingTransactionFilter | .Eth.NewPendingTransactionFilterAsync(...) | yes | yes | no |
| eth_uninstallFilter | .Eth.UninstallFilterAsync(...) | yes | yes | yes |
| eth_getFilterChanges | .Eth.GetFilterChangesAsync(...) | yes | no  | no |
| eth_getFilterLogs | .Eth.GetFilterLogsAsync(...) | yes | no | no |
| eth_getLogs | .Eth.GetLogsAsync(...) | yes | no | no |
| eth_getWork | .Eth.GetWorkAsync(...) | yes | partial | no |
| eth_submitWork | .Eth.SubmitWorkAsync(...) | yes | yes | no |
| eth_submitHashrate | .Eth.SubmitHashrateAsync(...) | yes | yes | no |
| miner_makeDAG |.Miner. | no |  |  |
| miner_start | .Miner.StartAsync(...) | yes | yes | yes |
| miner_startAutoDAG |.Miner. | no |  |  |
| miner_setExtra |.Miner. | no |  |  |
| miner_setGasPrice | .Miner.| no |  |  |
| miner_stop | .Miner.StopAsync(...) | yes | yes | yes |
| miner_stopAutoDAG | .Miner. | no |  |  |
| net_version | .Net.GetVersionAsync(...) | yes | yes | yes |
| net_listening | .Net.IsListeningAsync(...) | yes | partial | no |
| net_peerCount | .Net.GetPeerCountAsync(...) | yes | yes | no |
| personal_listAccounts | .Personal.ListAccountsAsync(...) | yes | yes | yes |
| personal_ecRecover | .Personal.| no |  |  |
| personal_importRawKey | .Personal. | no |  |  |
| personal_newAccount | .Personal. | no |  |  |
| personal_lockAccount | .Personal. | no |  |  |
| personal_unlockAccount | .Personal.UnlockAccountAsync(...) | yes | yes | yes |
| personal_sendTransaction | .Personal.SendTransactionAsync(...) | yes | partial | yes |
| personal_sign | .Personal.SignAsync(...) | yes | yes | no |
| shh_version | .Shh.GetVersionAsync(...) | yes | yes | no |
| shh_post | .Shh.PostAsync(...) | yes | no | no |
| shh_newIdentity | .Shh.NewIdentityAsync(...) | yes | yes | no |
| shh_hashIdentity | .Shh.HasIdentityAsync(...) | yes | yes | no |
| shh_newGroup | .Shh.NewGroupAsync(...) | yes | yes | no |
| shh_addToGroup | .Shh.AddToGroupAsync(...) | yes | yes | no |
| shh_newFilter | .Shh.NewFilterAsync(...) | yes | no | no |
| shh_uninstallFilter | .Shh.UninstallFilterAsync(...) | yes | yes | no |
| shh_getFilterChanges | .Shh.GetFilterChangesAsync(...) | yes | no | no |
| shh_getMessages | .Shh.GetMessagesAsync(...) | yes | no | no |
| txpool_content | .TxPool. | no | - | - |
| txpool_inspect | .TxPool. | no | - | - |
| txpool_status | .TxPool. | no | - | - |
| web3_clientVersion | .Web.Async(...) | yes | yes | no |
| web3_sha3 | .Web.Async(...) | yes | yes | no |



From [https://github.com/ethereum/go-ethereum/wiki/Management-APIs](https://github.com/ethereum/go-ethereum/wiki/Management-APIs) and [https://github.com/ethereum/wiki/wiki/JSON-RPC](https://github.com/ethereum/wiki/wiki/JSON-RPC)

