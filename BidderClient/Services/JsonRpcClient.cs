using BidderClient.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

public static class JsonRpcClient
{
    private static TcpClient client;
    private static NetworkStream stream;

    public static void Connect(string server, int port)
    {
        client = new TcpClient(server, port);
        stream = client.GetStream();
    }

    public static string SendRequest(string method, object parameters)
    {
        var request = new JsonRpcRequest
        {
            Method = method,
            Params = parameters,
            Id = 1 
        };

        string jsonRequest = JsonConvert.SerializeObject(request);
        byte[] requestData = Encoding.UTF8.GetBytes(jsonRequest);
        stream.Write(requestData, 0, requestData.Length);

       
        byte[] responseData = new byte[4096];
        int bytes = stream.Read(responseData, 0, responseData.Length);
        string jsonResponse = Encoding.UTF8.GetString(responseData, 0, bytes);

        return jsonResponse;
    }

    public static void Close()
    {
        stream.Close();
        client.Close();
    }
}
