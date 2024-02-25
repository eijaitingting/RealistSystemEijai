using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Subscription
{
    public class SubscriptionModel
    {
        public int SubscriptionID { get; set; } = 0;

        [Required]
        [Display(Name = "Subscription Type")]
        public int SubscriptionTypeID { get; set; } = 0;
        [Required]
        [Display(Name = "Agent")]
        public int AgentID { get; set; } = 0;
        [Required]
        [Display(Name = "Reference Number")]
        public String ReferenceNumber { get; set; } = String.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; } 
        public string SubPhoto { get; set; }
        public IFormFile? SubPhotoImage { get; set; }

    }
}
