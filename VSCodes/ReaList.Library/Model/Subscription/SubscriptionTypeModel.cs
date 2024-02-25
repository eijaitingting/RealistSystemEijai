using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Subscription
{
    public class SubscriptionTypeModel
    {
        public int SubscriptionTypeID { get; set; } = 0;
        [Required]
        [Display(Name = "Subscription Type Name")]
        public String SubscriptionTypeName { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Subscription Price")]
        public decimal SubscriptionPrice { get; set; } = 0;

    }
}
