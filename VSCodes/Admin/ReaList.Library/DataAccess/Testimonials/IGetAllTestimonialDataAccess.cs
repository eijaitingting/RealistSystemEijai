using ReaList.Library.Model.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Testimonials
{
    public interface IGetAllTestimonialDataAccess
    {
        Task<IEnumerable<AllTestimonials>> GetAllTestimonials();
    }
}
