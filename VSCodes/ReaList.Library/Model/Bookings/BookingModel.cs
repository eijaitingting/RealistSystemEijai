using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Bookings
{
    public class BookingModel
    {
        public int BookingID { get; set; } = 0;
        public int AgentID { get; set; } = 0;
        public int CustomerID { get; set; } = 0;
        public int PropertyID { get; set; } = 0;
        public DateTime VisitDate { get; set; }
        public string VisitTime { get; set; } = string.Empty;
        public int BookingStatus { get; set; } = 1;
        public int BookingPostStatus { get; set; } = 1;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

        /**/
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PropertyName { get; set;} = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public string PropertyCategoryName { get; set; } = string.Empty;
        public string PropertyTypeName { get; set; } = string.Empty;
        public string BookingStatusName { get; set; } = string.Empty;
        public string BookingPostStatusName { get; set; } = string.Empty;
        public string? MainPhoto { get; set; }

        /**/
        public int isRatingExists { get; set; } = 0;
    }
}
