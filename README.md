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
