using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPP.Models
{  
    public class Auction
    {
        public string Title { get; set; }
        public string Picture { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal Price { get; set; }    
    }
}
