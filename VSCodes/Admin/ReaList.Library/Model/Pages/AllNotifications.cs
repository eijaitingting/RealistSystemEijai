using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Pages
{
    public class AllNotifications
    {
        public int NotificationID { get; set; } = 0;
        public int AgentID { get; set; } = 0;
        public int CustomerID { get; set; } = 0;
        public string NotificationTitle { get; set; } = String.Empty;
        public string NotificationDetails { get; set; } = String.Empty;
        public bool IsRead { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
