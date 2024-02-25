using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Testimonies
{
    public class TestimoniesModel
    {
        public int TestimonyID { get; set; } = 0;
        public int AgentID { get; set; } = 0;
        public string Testimony { get; set; } = String.Empty;
        public byte isDisplayed { get; set; } = 0;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
