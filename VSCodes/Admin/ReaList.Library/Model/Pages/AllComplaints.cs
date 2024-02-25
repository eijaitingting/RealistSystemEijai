using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Pages
{
    public class AllComplaints
    {
        public int ComplaintsID { get; set; } = 0;
        public int AgentID { get; set; } = 0;
        public int CustomerID { get; set; } = 0;
        public int ComplaintCategory { get; set; }
        public DateTime DateOfEvent { get; set; }

        [Required]
        [Display(Name = "Complaint Subject")]
        public string ComplaintSubject { get; set; } = String.Empty;




        [Required]
        [Display(Name = "Complaint Details")]
        public string ComplaintDetails { get; set; } = String.Empty;

        [Required]
        [Display(Name = "Complaint Images")]
        public byte[]? ComplaintImages { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
