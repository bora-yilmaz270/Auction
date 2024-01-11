using MainAPP.Models;
using Newtonsoft.Json;
using StreamJsonRpc.Protocol;

namespace MainAPP.Services
{
    public static class HandleStartAuctionService
    {
        public static string HandleStartAuction(string auctionDetails)
        {
            try
            {
               
                var auction = JsonConvert.DeserializeObject<Auction>(auctionDetails);
              
                SaveAuctionToDatabase(auction);
               
                NotifyParticipants(auction);

                return "Auction started for: " + auction.Picture;

            }
            catch (Exception e)
            {
                return "Error starting the auction: " + e.Message;
            }
        }

        public static void SaveAuctionToDatabase(Auction auction)
        {
            // Database save operations are done here
        }

        public static void NotifyParticipants(Auction auction)
        {
            // Operations to notify other participants that the auction has started are done here
        }
    }
}
