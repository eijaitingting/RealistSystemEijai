using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Complaints
{
    public class ComplaintsModel
    {
        public int ComplaintID { get; set; } = 0;
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
        public byte ComplaintImages { get; set; }
        public int ComplaintStatus { get; set; } = 1;
        public DateTime DateCreated { get; set; } = DateTime.Now;

        /**/

        public string ComplaintCategoryName { get; set; } = string.Empty;

        public string ComplaintStatusName { get; set; } = string.Empty;
    }
}
