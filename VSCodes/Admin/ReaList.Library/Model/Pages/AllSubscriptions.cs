using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Pages
{
    public class AllSubscriptions
    {
        public int SubscriptionID { get; set; } = 0;
        public int SubscriptionTypeID { get; set; } = 0;
        public int AgentID { get; set; } = 0;
        public int ReferenceNumber { get; set; } = 0;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; } = DateTime.Now.AddMonths(1);
        public bool IsActive { get; set; }
    }
}
