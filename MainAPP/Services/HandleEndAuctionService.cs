using MainAPP.Models;
using Newtonsoft.Json;

namespace MainAPP.Services
{
    public static class HandleEndAuctionService
    {
        public static string HandleEndAuction(string endbid)
        {
            try
            {                
                var bid = JsonConvert.DeserializeObject<EndBid>(endbid);
                int id = bid.AuctionId;
              
                var auctionResult = ProcessAuctionResults(id);
              
                SaveAuctionResultsToDatabase(auctionResult);
               
                NotifyParticipantsAboutAuctionEnd(auctionResult);

                return $"Auction finalized: {auctionResult.AuctionTitle}, sold to {auctionResult.Winner} for {auctionResult.WinningBid} USDt.";
            }
            catch (Exception e)
            {
                return "Error finalizing the auction: " + e.Message;
            }
        }
        private static AuctionResult  ProcessAuctionResults(int auctionId)
        {
            // Database queries and business logic will be performed
            // Using fixed values as an example
            var auctionResult = new AuctionResult
            {
                AuctionTitle = "Pic#" + auctionId, 
                WinningBid = 80.0m,
                Winner = "Client#2" 
            };
            return auctionResult;
        }

        public static void SaveAuctionResultsToDatabase(AuctionResult auctionResult)
        {
            // Database saving operations are done here
        }
        public static void NotifyParticipantsAboutAuctionEnd(AuctionResult auctionResult)
        {
            // Operations to inform other participants about the auction results are done here
        }
    }
}
