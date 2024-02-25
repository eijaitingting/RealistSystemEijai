using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Pages
{
    public class AllTestimonials
    {
        public int TestimonyID { get; set; }
        public int AgentID { get; set; }
        public string Testimony { get; set; } = String.Empty;
        public bool isDisplayed { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
