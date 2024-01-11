using MainAPP.Services;
using Newtonsoft.Json;
using StreamJsonRpc.Protocol;
using System.Net;
using System.Net.Sockets;
using System.Text;
public class AuctionServer
{
    
    private static Socket serverSocket;

    private static int port = 12345; 

    public static void StartServer()
    {
        // Create TCP/IP socket
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
       
        serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
      
        serverSocket.Listen(10);

        Console.WriteLine($"Server started listening on port {port}.");


        while (true)
        {
            // Accept client connection
            Socket clientSocket = serverSocket.Accept();

            // Start a thread to handle requests from the client
            Thread clientThread = new Thread(() => HandleClient(clientSocket));
            clientThread.Start();
        }
    }

    private static void HandleClient(Socket clientSocket)
    {
        try
        {
           
            byte[] buffer = new byte[1024];
            int received = clientSocket.Receive(buffer);
            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string jsonRequest = Encoding.ASCII.GetString(data);
            
            var request = JsonConvert.DeserializeObject<JsonRpcRequest>(jsonRequest);
            
            string response;
            switch (request.Method)
            {
                case "StartAuction":                              
                    response = HandleStartAuctionService.HandleStartAuction(request.Arguments.ToString());                   
                    break;
                case "PlaceBid":                   
                    response = HandlePlaceBidService.HandlePlaceBid(request.Arguments.ToString());
                    break;
                case "EndAuction":                   
                    response = HandleEndAuctionService.HandleEndAuction(request.Arguments.ToString());
                    break;
                default:
                    response = "Bilinmeyen metod";
                    break;
            }

            // Send the response to the client
            byte[] responseData = Encoding.ASCII.GetBytes(response);
            clientSocket.Send(responseData);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in client communication: " + e.Message);
        }
        finally
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }

}

