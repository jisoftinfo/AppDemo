using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swift.PLWeb.Models
{
    public class COItem
    {
        public decimal UID { get; set; }
        
        
    }

    public class COItemSchedule
    {
        public decimal ItemUID { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Qty { get; set; }
    }
}