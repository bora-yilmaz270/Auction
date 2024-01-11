namespace BidderClient.Models
{
    public class JsonRpcRequest
    {
        public string jsonrpc { get; set; } = "2.0"; 
        public string Method { get; set; }
        public object Params { get; set; }
        public int Id { get; set; }
    }

}
