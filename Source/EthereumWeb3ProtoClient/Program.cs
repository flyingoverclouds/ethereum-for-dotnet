using EthereumGethRpc;
using EthereumGethRpc.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EthereumWeb3ProtoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var prog = new Program();
            //prog.GethRpcTestRun().GetAwaiter().GetResult();

            //prog.SingleAccountTransfer().GetAwaiter().GetResult();

            //prog.DeployContract().GetAwaiter().GetResult();

            //prog.GetTransactionData().GetAwaiter().GetResult();

            prog.TestV2().GetAwaiter().GetResult();

            Console.WriteLine("\r\nPRESS ENTER TO TERMINATE");
            Console.ReadLine();
        }
        async Task TestV2()
        {
            try
            {
                Uri gethNodeUrl = new Uri("http://fdclbcvm.westeurope.cloudapp.azure.com:16969");
                var geth = new GethRpcProxy(gethNodeUrl);

                var modules = await geth.GetModules();
                foreach (var m in modules)
                {
                    Console.WriteLine("              " + m);
                }

                Console.WriteLine("MODULES: ");
                Console.WriteLine("DateDir=" + await geth.Admin.GetDataDir());


            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION : " + ex.ToString());
            }
        }
            async Task DeployContract()
        {
            Console.WriteLine(">------- Contract Deployment :");
            try
            {
                //Uri web3NodeUrl = new Uri("http://192.168.92.104:16969");
                Uri web3NodeUrl = new Uri("http://fdclbcvm.westeurope.cloudapp.azure.com:16969");

                var addressFrom = "0x12890d2cce102216644c59daE5baed380d84830c"; // PRECREDITED ACCOUNT IN DEV testchain CHAIN
                var addressTo = "0x13f022d72158410433cbd66f5dd8bf6d2d129924";
                var password = "password";

                string amount = "0x1000";

                // bytecode & abi generated using https://ethereum.github.io/browser-solidity/#version=soljson-v0.4.10+commit.f0d539ae.js

                var jsonData = " { \"hash1\":\"hash2\"  }";
                var hexData = jsonData.ToHex();

                
                var web3 = new GethRpcProxy(web3NodeUrl);

                var accountBalance = await web3.Eth.GetBalanceAsync(addressFrom);

                if (!await web3.Personal_UnlockAccountAsync(addressFrom, password))
                {
                    Console.WriteLine("ERROR : unable to unlock " + addressFrom);
                    return;
                }

                var trx = new Transaction()
                {
                    From = addressFrom,
                    To = addressTo,
                    Value = amount,
                    Data = hexData
                };
                var trxId = await web3.Eth.SendTransactionAsync(trx); 
                Console.WriteLine("Eth_SendTransaction: trxId :" + trxId);
                TransactionReceipt receipt = null;
                int attempt = 0;
                while (true)
                {
                    await Task.Delay(500);
                    Console.Write($"attempt #{++attempt} to get receipt ..... \r");
                    receipt = await web3.Eth.GetTransactionReceiptAsync(trxId);
                    if (receipt != null)
                        break;
                }
                Console.WriteLine(" trx receipt  = " + receipt);

            //http://ethereum.stackexchange.com/questions/3514/how-to-call-a-contract-method-using-the-eth-call-json-rpc-api

                Console.WriteLine("TOTO");
            }
            catch (JsonRpcException jex)
            {
                Console.WriteLine("EXCEPTION: " + jex.ToString());
            }
        }

        async Task GetTransactionData()
        {
            Uri web3NodeUrl = new Uri("http://fdclbcvm.westeurope.cloudapp.azure.com:16969");
            var web3 = new GethRpcProxy(web3NodeUrl);

            string hash = "0xc7a7dc3718cf010d1ea0556751e760df6033e39106a71d4215d856bda063258b";
            string blockNum = "0x457";
            string trxNdx = "0x0";

            Transaction trx;
            trx = await web3.Eth.GetTransactionByHashAsync(hash);
            var data = trx.Input.FromHex();
            Console.WriteLine($"Transaction [{hash}] = {data}");

            trx = await web3.Eth.GetTransactionByBlockNumberAndIndexAsync(blockNum, trxNdx);
            data = trx.Input.FromHex();
            Console.WriteLine($"Transaction [{blockNum} , {trxNdx}] = {data}");



        }

        

        async Task SingleAccountTransfer()
        {
            Console.WriteLine(">------- SingleAccountTransfer :");
            try
            {
                // based on https://github.com/Nethereum/MultipleAccountTransferSample/blob/master/Program.cs
                Uri web3NodeUrl = new Uri("http://192.168.92.104:16969");


                var addressFrom = "0x12890d2cce102216644c59daE5baed380d84830c"; // PRECREDITED ACCOUNT IN DEV CHAIN
                var addressTo = "0x13f022d72158410433cbd66f5dd8bf6d2d129924";

                var password = "password";

                var web3 = new GethRpcProxy(web3NodeUrl);

                var accountBalance = await web3.Eth.GetBalanceAsync(addressFrom);

                if (!await web3.Personal_UnlockAccountAsync(addressFrom, password))
                {
                    Console.WriteLine("ERROR : unable to unlock " + addressFrom);
                    return;
                }

                var accounts = await web3.Eth.GetAccountsAsync();
                //Console.WriteLine("ENTER to START MINING");
                //Console.ReadLine();
                //await web3.Miner_StartAsync();

                var balance = await web3.Eth.GetBalanceAsync(addressFrom);
                Console.WriteLine("INITIAL SENDER account balance is : " + balance);

                balance = await web3.Eth.GetBalanceAsync(addressTo);
                Console.WriteLine("INITIAL TARGET account balance is : " + balance);

                string amount = "0x1000";

                Console.WriteLine("Transfering " + amount + "  to " + addressTo);
                var trx = new Transaction()
                {
                    From = addressFrom,
                    To = addressTo,
                    Value = amount,
                    Data = "" // NO specific contract ABI attached to the transaction 
                };
                var trxId = await web3.Eth.SendTransactionAsync(trx);
                Console.WriteLine("Eth_SendTransaction: trxId :" + trxId);

                TransactionReceipt receipt = null;
                int attempNum = 0;
                while (true)
                {
                    await Task.Delay(500);
                    Console.Write($"attempt #{++attempNum} to get receipt ..... \r");
                    receipt = await web3.Eth.GetTransactionReceiptAsync(trxId);
                    if (receipt!=null)
                    {
                        break;
                    }
                }
                Console.WriteLine(" trx receipt  = " + receipt);

                balance = await web3.Eth.GetBalanceAsync(addressFrom);
                Console.WriteLine("SENDER account balance is : " + balance);

                balance = await web3.Eth.GetBalanceAsync(addressTo);
                Console.WriteLine("TARGET account balance is : " + balance);

                Console.WriteLine();

                Console.WriteLine($"Checking transaction by BlockNumber{receipt.BlockNumber}= TransactionIndex={receipt.TransactionIndex} : ");
                var trxCheck = await web3.Eth.GetTransactionByBlockNumberAndIndexAsync(receipt.BlockNumber, receipt.TransactionIndex);
                Console.WriteLine(trxCheck);

                Console.WriteLine($"Checking transaction by BlockHash{receipt.BlockHash}= TransactionIndex={receipt.TransactionIndex} : ");
                trxCheck = await web3.Eth.GetTransactionByBlockHashAndIndexAsync(receipt.BlockHash, receipt.TransactionIndex);
                Console.WriteLine(trxCheck);


                Console.WriteLine($"Checking transaction by Hash={receipt.TransactionHash} : ");
                trxCheck = await web3.Eth.GetTransactionByHashAsync(receipt.TransactionHash);
                Console.WriteLine(trxCheck);

                var b = web3.Eth.GetBlockByHashAsync(receipt.BlockHash,true);
                var b1 = web3.Eth.GetBlockByNumberAsync(receipt.BlockNumber,true);
                Console.WriteLine();

            }
            catch (JsonRpcException jex)
            {
                Console.WriteLine("EXCEPTION JSONRPC: " + jex.ToString());
            }
        }





        async Task GethRpcTestRun()
        {
            Console.WriteLine("****** Running basic tests .....");
           

            Uri web3NodeUrl = new Uri("http://192.168.92.104:16969");
            string accountKeyPass = "password";

            GethRpcProxy nodeApi = new GethRpcProxy(web3NodeUrl);

            try
            {
                Console.WriteLine("MODULES: ");
                var modules = await nodeApi.GetModules();
                foreach (var m in modules)
                {
                    Console.WriteLine("              " + m);
                }

                Console.WriteLine();
                Console.WriteLine("ADMIN: DataFolder : " + await nodeApi.Admin.GetDataDir());

                Console.WriteLine();
                Console.WriteLine("ETH: protocolVersion : " + await nodeApi.Eth.GetProtocolVersionAsync());
                Console.WriteLine("ETH: coinbase : " + await nodeApi.Eth.GetCoinbaseAddressAsync());
                var syncing = await nodeApi.Eth.SyncingStatusAsync();
                Console.WriteLine("ETH: syncing : " + ((syncing == null) ? "NOT SYNCING" : syncing.ToString()));
                Console.WriteLine("ETH: mining : " + await nodeApi.Eth.IsMiningAsync());
                Console.WriteLine("ETH: hashrate : " + await nodeApi.Eth.GetHashRateAsync());
                Console.WriteLine("ETH: gasPrice : " + await nodeApi.Eth.GetGasPriceAsync());
                Console.WriteLine("ETH: blockNumber : " + await nodeApi.Eth.GetMostRecentBlockNumberAsync());
                Console.WriteLine("ETH: accounts : ");
                var accounts = await nodeApi.Eth.GetAccountsAsync();
                foreach (var acc in accounts)
                {
                    Console.WriteLine("      #" + acc);
                    Console.WriteLine("            balance : " + await nodeApi.Eth.GetBalanceAsync(acc) + ".wei");
                    Console.WriteLine("            transactionCount : " + await nodeApi.Eth.GetTransactionCountAsync(acc));

                }
                //Console.WriteLine("ETH: test sign : " + await nodeApi.Eth_Sign(accounts[0], "0x112233445566778899aabbccddeeff"));
                Console.WriteLine("ETH: estimateGas :" + await nodeApi.Eth.EstimateGasAsync());

                //var block = await nodeApi.Eth_GetBlockByNumber("latest", false);
                //var blockDetailed = await nodeApi.Eth_GetBlockByNumber("latest", true);

                //var trx = await nodeApi.Eth_GetTransactionByHash("0x0000000000000000000000000000000000000000000000000000000000000000");
                //var trx2 = await nodeApi.Eth_GetTransactionByBlockNumberAndIndex("0x0", "0X0");

                string contractCode = "pragma solidity ^0.4.0; contract MesMath { function multiply(uint a) returns(uint d) {   return a * 7;   } }";
                var abi = await nodeApi.Eth.CompileSolidityAsync(contractCode);

                
                Console.Write("ETH: getCompilers : [ ");
                foreach (var c in await nodeApi.Eth.GetCompilersAsync())
                    Console.Write($"{c}  ");
                Console.WriteLine("] ");

                var blockFilter = await nodeApi.Eth.NewBlockFilterAsync();
                Console.WriteLine("ETH: newBlockFilter : " + blockFilter);
                Console.WriteLine("ETH:     uninstallFilter : " + await nodeApi.Eth.UninstallFilterAsync(blockFilter));
                var trxFilter = await nodeApi.Eth.NewPendingTransactionFilterAsync();
                Console.WriteLine("ETH: newPendingTransactionFilter : " + trxFilter);
                var chg = await nodeApi.Eth.GetFilterChangesAsync(trxFilter);
                Console.WriteLine("ETH:     uninstallFilter : " + await nodeApi.Eth.UninstallFilterAsync(trxFilter));
                Console.WriteLine("ETH:     uninstallFilter : " + await nodeApi.Eth.UninstallFilterAsync(trxFilter));
                var t = await nodeApi.Eth.CallAsync("0x000000000000000000000000a94f5374fce5edbc8e2a8697c15331677e6ebf0b", "0x000000000000000000000000a94f5374fce5edbc8e2a8697c15331677e6effff");
                var works = await nodeApi.Eth.GetWorkAsync();
                Console.WriteLine("ETH: submitWork : " + await nodeApi.Eth.SubmitWorkAsync("0x0000000000000001", "0x1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef", "0x000000000000000000000000a94f5374fce5edbc8e2a8697c15331677e6effff"));
                Console.WriteLine("ETH: submitHashRate : " + await nodeApi.Eth.SubmitHashRateAsync("0x500000", "0x59daa26581d0acd1fce254fb7e85952f4c09d0915afd33d3886cd914bc7d283c"));
                //Console.WriteLine("ETH: putString : " + await nodeApi.Eth_PutString("testDb", "nicolas", "clerc"));
                //Console.WriteLine("ETH: getString : " + await nodeApi.Eth_GetString("testDb", "nicolas"));
                Console.WriteLine();

                //Console.WriteLine("SHH: version : " + await nodeApi.Shh_GetVersion());

                Console.WriteLine();
                Console.WriteLine("NET: version : " + await nodeApi.Net.GetVersion());
                Console.WriteLine("NET: listening : " + await nodeApi.Net.IsListening());
                Console.WriteLine("NET: peerCount : " + await nodeApi.Net.GetPeerCount());

                Console.WriteLine();
                Console.WriteLine("WEB3: clientVersion : " + await nodeApi.Web3.GetClientVersion());
                Console.WriteLine("WEB3: sha3 : " + await nodeApi.Web3.GetSha3("0x68656c6c6f20776f726c64"));

                Console.WriteLine();
                Console.WriteLine("PERSONAL: listAccounts :");
                var accs = await nodeApi.Personal_ListAccounts();
                foreach (var a in accs)
                {
                    Console.WriteLine("              " + a);
                }
                Console.Write("PERSONAL: unlockAccount: " + await nodeApi.Personal_UnlockAccountAsync(accs[1], accountKeyPass, 10));


            }
            catch (JsonRpcException jrex)
            {
                Console.WriteLine($"EXCEPTION JSON : [{jrex.RpcErrorCode}] {jrex.ToString()} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION : " + ex.ToString());
            }

            return;
        }

    }

}