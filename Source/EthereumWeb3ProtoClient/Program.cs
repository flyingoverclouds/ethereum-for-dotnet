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
        // Custoize this url to connect to your geth rpc endpoint
        const string GethEndpointUrl = "http://fdclbcvm.westeurope.cloudapp.azure.com:16969";
        const string coinbaseAddress = "0xb0f360df1a8df50699191344e714204844da1c6f";
        const string account1 = "0xdbb9a6624e931d8915521ac4bca2ea5aa746e06e";
        const string account2 = "0xe498ef1d9b70f21d91d0f6f9ec0517a50682adb6";
        static string password = "password";
        static void Main(string[] args)
        {
            Console.Write("Accounts password : ");
            var p = Console.ReadLine();
            if (!string.IsNullOrEmpty(p))
                password = p;

            var prog = new Program();
            //prog.GethRpcTestRun().GetAwaiter().GetResult();

            //prog.SingleAccountTransfer().GetAwaiter().GetResult();

            //prog.DeployContract().GetAwaiter().GetResult();

            prog.DisplayTxPool().GetAwaiter().GetResult();

            //prog.GetTransactionData().GetAwaiter().GetResult();

            Console.WriteLine("\r\nPRESS ENTER TO TERMINATE");
            Console.ReadLine();
        }

        async Task DisplayTxPool()
        {
            Console.WriteLine(">------- Contract Deployment :");
            try
            {
                Uri gethNodeUrl = new Uri(GethEndpointUrl);
                var gethProxy = new GethRpcProxy(gethNodeUrl);

            }
            catch (JsonRpcException jex)
            {
                Console.WriteLine("EXCEPTION: " + jex.ToString());
            }
        }

        async Task DeployContract()
        {
            Console.WriteLine(">------- Contract Deployment :");
            try
            {
                Uri gethProxyUrl = new Uri(GethEndpointUrl);

                var addressFrom = coinbaseAddress; // PRECREDITED ACCOUNT IN DEV testchain CHAIN
                var addressTo = account1;

                string amount = "0x1000";

                var jsonData = " { \"hash1\":\"" + DateTime.Now.ToString("u") + "\"  }";
                var hexData = jsonData.ToHex();

                
                var gethProxy = new GethRpcProxy(gethProxyUrl);

                var accountBalance = await gethProxy.Eth.GetBalanceAsync(addressFrom);

                if (!await gethProxy.Personal.UnlockAccountAsync(addressFrom, password))
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
                var trxId = await gethProxy.Eth.SendTransactionAsync(trx); 
                Console.WriteLine("Eth_SendTransaction: trxId :" + trxId);
                TransactionReceipt receipt = null;
                int attempt = 0;
                while (true)
                {
                    await Task.Delay(500);
                    Console.Write($"attempt #{++attempt} to get receipt ..... \r");
                    receipt = await gethProxy.Eth.GetTransactionReceiptAsync(trxId);
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
            Uri gethNodeUrl = new Uri(GethEndpointUrl);
            var gethProxy = new GethRpcProxy(gethNodeUrl);

            string hash = "0xc7a7dc3718cf010d1ea0556751e760df6033e39106a71d4215d856bda063258b";
            string blockNum = "0x457";
            string trxNdx = "0x0";

            Transaction trx;
            trx = await gethProxy.Eth.GetTransactionByHashAsync(hash);
            var data = trx.Input.FromHex();
            Console.WriteLine($"Transaction [{hash}] = {data}");

            trx = await gethProxy.Eth.GetTransactionByBlockNumberAndIndexAsync(blockNum, trxNdx);
            data = trx.Input.FromHex();
            Console.WriteLine($"Transaction [{blockNum} , {trxNdx}] = {data}");



        }

        

        async Task SingleAccountTransfer()
        {
            Console.WriteLine(">------- SingleAccountTransfer :");
            try
            {
                // based on https://github.com/Nethereum/MultipleAccountTransferSample/blob/master/Program.cs
                Uri gethNodeUrl = new Uri(GethEndpointUrl);


                var addressFrom = "0x12890d2cce102216644c59daE5baed380d84830c"; // PRECREDITED ACCOUNT IN DEV CHAIN
                var addressTo = "0x13f022d72158410433cbd66f5dd8bf6d2d129924";

                var password = "password";

                var gethProxy = new GethRpcProxy(gethNodeUrl);

                var accountBalance = await gethProxy.Eth.GetBalanceAsync(addressFrom);

                if (!await gethProxy.Personal.UnlockAccountAsync(addressFrom, password))
                {
                    Console.WriteLine("ERROR : unable to unlock " + addressFrom);
                    return;
                }

                var accounts = await gethProxy.Eth.GetAccountsAsync();
                //Console.WriteLine("ENTER to START MINING");
                //Console.ReadLine();
                //await web3.Miner_StartAsync();

                var balance = await gethProxy.Eth.GetBalanceAsync(addressFrom);
                Console.WriteLine("INITIAL SENDER account balance is : " + balance);

                balance = await gethProxy.Eth.GetBalanceAsync(addressTo);
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
                var trxId = await gethProxy.Eth.SendTransactionAsync(trx);
                Console.WriteLine("Eth_SendTransaction: trxId :" + trxId);

                TransactionReceipt receipt = null;
                int attempNum = 0;
                while (true)
                {
                    await Task.Delay(500);
                    Console.Write($"attempt #{++attempNum} to get receipt ..... \r");
                    receipt = await gethProxy.Eth.GetTransactionReceiptAsync(trxId);
                    if (receipt!=null)
                    {
                        break;
                    }
                }
                Console.WriteLine(" trx receipt  = " + receipt);

                balance = await gethProxy.Eth.GetBalanceAsync(addressFrom);
                Console.WriteLine("SENDER account balance is : " + balance);

                balance = await gethProxy.Eth.GetBalanceAsync(addressTo);
                Console.WriteLine("TARGET account balance is : " + balance);

                Console.WriteLine();

                Console.WriteLine($"Checking transaction by BlockNumber{receipt.BlockNumber}= TransactionIndex={receipt.TransactionIndex} : ");
                var trxCheck = await gethProxy.Eth.GetTransactionByBlockNumberAndIndexAsync(receipt.BlockNumber, receipt.TransactionIndex);
                Console.WriteLine(trxCheck);

                Console.WriteLine($"Checking transaction by BlockHash{receipt.BlockHash}= TransactionIndex={receipt.TransactionIndex} : ");
                trxCheck = await gethProxy.Eth.GetTransactionByBlockHashAndIndexAsync(receipt.BlockHash, receipt.TransactionIndex);
                Console.WriteLine(trxCheck);


                Console.WriteLine($"Checking transaction by Hash={receipt.TransactionHash} : ");
                trxCheck = await gethProxy.Eth.GetTransactionByHashAsync(receipt.TransactionHash);
                Console.WriteLine(trxCheck);

                var b = gethProxy.Eth.GetBlockByHashAsync(receipt.BlockHash,false);
                var b1 = gethProxy.Eth.GetBlockByNumberAsync(receipt.BlockNumber,false);
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
           

            Uri gethNodeUrl = new Uri(GethEndpointUrl);
            string accountKeyPass = "password";

            GethRpcProxy gethProxy = new GethRpcProxy(gethNodeUrl);

            try
            {
                Console.WriteLine("MODULES: ");
                var modules = await gethProxy.GetModulesAsync();
                foreach (var m in modules)
                {
                    Console.WriteLine("              " + m);
                }

                Console.WriteLine();
                Console.WriteLine("ADMIN: DataFolder : " + await gethProxy.Admin.GetDataDirAsync());

                Console.WriteLine();
                Console.WriteLine("ETH: protocolVersion : " + await gethProxy.Eth.GetProtocolVersionAsync());
                Console.WriteLine("ETH: coinbase : " + await gethProxy.Eth.GetCoinbaseAddressAsync());
                var syncing = await gethProxy.Eth.SyncingStatusAsync();
                Console.WriteLine("ETH: syncing : " + ((syncing == null) ? "NOT SYNCING" : syncing.ToString()));
                Console.WriteLine("ETH: mining : " + await gethProxy.Eth.IsMiningAsync());
                Console.WriteLine("ETH: hashrate : " + await gethProxy.Eth.GetHashRateAsync());
                Console.WriteLine("ETH: gasPrice : " + await gethProxy.Eth.GetGasPriceAsync());
                Console.WriteLine("ETH: blockNumber : " + await gethProxy.Eth.GetBlockNumberAsync());
                Console.WriteLine("ETH: accounts : ");
                var accounts = await gethProxy.Eth.GetAccountsAsync();
                foreach (var acc in accounts)
                {
                    Console.WriteLine("      #" + acc);
                    //Console.WriteLine("            balance : " + await gethProxy.Eth.GetBalanceAsync(acc) + ".wei");
                    //Console.WriteLine("            transactionCount : " + await gethProxy.Eth.GetTransactionCountAsync(acc));
                }
                await gethProxy.Personal.UnlockAccountAsync(accounts[0], "password");
                Console.WriteLine("ETH: test sign : " + await gethProxy.Eth.SignAsync(accounts[0], "Nicolas".ToHex()));
                Transaction trxGasEstimate = new Transaction() { }; 
                Console.WriteLine("ETH: estimateGas :" + await gethProxy.Eth.EstimateGasAsync(trxGasEstimate));

                var block = await gethProxy.Eth.GetBlockByNumberAsync("latest", false);
                var blockDetailed = await gethProxy.Eth.GetBlockByNumberAsync("latest", false);

                var trx = await gethProxy.Eth.GetTransactionByHashAsync("0x0000000000000000000000000000000000000000000000000000000000000000");
                var trx2 = await gethProxy.Eth.GetTransactionByBlockNumberAndIndexAsync("0x0", "0X0");

                Console.Write("ETH: getCompilers : [ ");
                foreach (var c in await gethProxy.Eth.GetCompilersAsync())
                    Console.Write($"{c}  ");
                Console.WriteLine("] ");

                //string contractCode = "pragma solidity ^0.4.0; contract MesMath { function multiply(uint a) returns(uint d) {   return a * 7;   } }";
                //var abi = await gethProxy.Eth.CompileSolidityAsync(contractCode);

                var blockFilter = await gethProxy.Eth.NewBlockFilterAsync();
                Console.WriteLine("ETH: newBlockFilter : " + blockFilter);
                Console.WriteLine("ETH:     uninstallFilter : " + await gethProxy.Eth.UninstallFilterAsync(blockFilter));
                var trxFilter = await gethProxy.Eth.NewPendingTransactionFilterAsync();
                Console.WriteLine("ETH: newPendingTransactionFilter : " + trxFilter);
                var chg = await gethProxy.Eth.GetFilterChangesAsync(trxFilter);
                Console.WriteLine("ETH:     uninstallFilter : " + await gethProxy.Eth.UninstallFilterAsync(trxFilter));
                Console.WriteLine("ETH:     uninstallFilter : " + await gethProxy.Eth.UninstallFilterAsync(trxFilter));

                trx = new Transaction()
                {

                };
                var t = await gethProxy.Eth.CallAsync(trx);
                var works = await gethProxy.Eth.GetWorkAsync();
                Console.WriteLine("ETH: submitWork : " + await gethProxy.Eth.SubmitWorkAsync("0x0000000000000001", "0x1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef", "0x000000000000000000000000a94f5374fce5edbc8e2a8697c15331677e6effff"));
                Console.WriteLine("ETH: submitHashRate : " + await gethProxy.Eth.SubmitHashrateAsync("0x500000", "0x59daa26581d0acd1fce254fb7e85952f4c09d0915afd33d3886cd914bc7d283c"));
                //Console.WriteLine("ETH: putString : " + await nodeApi.Eth_PutString("testDb", "nicolas", "clerc"));
                //Console.WriteLine("ETH: getString : " + await nodeApi.Eth_GetString("testDb", "nicolas"));
                Console.WriteLine();

                //Console.WriteLine("SHH: version : " + await nodeApi.Shh_GetVersion());

                Console.WriteLine();
                Console.WriteLine("NET: version : " + await gethProxy.Net.GetVersionAsync());
                Console.WriteLine("NET: listening : " + await gethProxy.Net.IsListeningAsync());
                Console.WriteLine("NET: peerCount : " + await gethProxy.Net.GetPeerCountAsync());

                Console.WriteLine();
                Console.WriteLine("WEB3: clientVersion : " + await gethProxy.Web3.GetClientVersionAsync());
                Console.WriteLine("WEB3: sha3 : " + await gethProxy.Web3.GetSha3Async("Nicolas".ToHex()));

                Console.WriteLine();
                Console.WriteLine("PERSONAL: listAccounts :");
                var accs = await gethProxy.Personal.ListAccountsAsync();
                foreach (var a in accs)
                {
                    Console.WriteLine("              " + a);
                }
                Console.Write("PERSONAL: unlockAccount: " + await gethProxy.Personal.UnlockAccountAsync(accs[1], accountKeyPass, 10));


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