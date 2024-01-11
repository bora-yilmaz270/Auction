namespace BidderClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(3000);

           
            string serverAddress = "127.0.0.1"; 
            int port = 12345;

            // Client#1: Start auction - Pic#1, 75 USDt
            JsonRpcClient.Connect(serverAddress, port);
            string response=JsonRpcClient.SendRequest("StartAuction", new { Picture = "Pic#1", Price = 75 });
            Console.WriteLine("Server Response: " + response);
            JsonRpcClient.Close();
            
            Thread.Sleep(3000);

            // Client#2: Start auction - Pic#2, 60 USDt
            JsonRpcClient.Connect(serverAddress, port);
            response= JsonRpcClient.SendRequest("StartAuction", new { Picture = "Pic#2", Price = 60 });
            Console.WriteLine("Server Response: " + response);
            JsonRpcClient.Close();
          
            Thread.Sleep(3000);

            // Client#2: Bids 75 USDt for Client#1's Pic#1
            JsonRpcClient.Connect(serverAddress, port);
            response= JsonRpcClient.SendRequest("PlaceBid", new { AuctionId = 1, BidAmount = 75 });
            Console.WriteLine("Server Response: " + response);
            JsonRpcClient.Close();
           
            Thread.Sleep(3000);

            // Client#3: Bids 75.5 USDt for the same Pic
            JsonRpcClient.Connect(serverAddress, port);
            response=JsonRpcClient.SendRequest("PlaceBid", new { AuctionId = 1, BidAmount = 75.5 });
            Console.WriteLine("Server Response: " + response);
            JsonRpcClient.Close();
           
            Thread.Sleep(3000);

            // Client#2: Bids 80 USDt for the same Pic
            JsonRpcClient.Connect(serverAddress, port);
            response=JsonRpcClient.SendRequest("PlaceBid", new { AuctionId = 1, BidAmount = 80 });
            Console.WriteLine("Server Response: " + response);
            JsonRpcClient.Close();
         
            Thread.Sleep(3000);

            // Client#1: Finalizes the auction - Pic#1, 80 USDt
            JsonRpcClient.Connect(serverAddress, port);
            response= JsonRpcClient.SendRequest("EndAuction", new { AuctionId = 1 });
            Console.WriteLine("Server Response: " + response);
            JsonRpcClient.Close();
        }
    }
}
