using MainAPP.Models;
using Newtonsoft.Json;

namespace MainAPP.Services
{
    public static class HandlePlaceBidService
    {
        public static string HandlePlaceBid(string bidDetails)
        {
            try
            {
                var bid = JsonConvert.DeserializeObject<Bid>(bidDetails);

                if (!IsBidValid(bid))
                {
                    return "Invalid bid.";
                }

                SaveBidToDatabase(bid);

                NotifyParticipantsAboutBid(bid);

                return "Bid successfully placed: " + bid.BidAmount;

            }
            catch (Exception e)
            {
                return "Error processing the bid: " + e.Message;
            }
        }

        public static bool IsBidValid(Bid bid)
        {
            return true;
        }

        public static void SaveBidToDatabase(Bid bid)
        {
            // Database save operations are performed here
        }

        public static void NotifyParticipantsAboutBid(Bid bid)
        {
            // Operations to inform other participants about the bid are done here
        }
    }
}
