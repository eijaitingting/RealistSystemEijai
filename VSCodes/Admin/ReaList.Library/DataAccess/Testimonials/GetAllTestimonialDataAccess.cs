using ReaList.Library.Helper;
using ReaList.Library.Model.Pages;
using ReaList.Library.DataAccess.Testimonials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Testimonials
{
    public class GetAllTestimonialDataAccess : IGetAllTestimonialDataAccess
    {
        private readonly ISqlDataAccess _dataAccess2;
        public GetAllTestimonialDataAccess(ISqlDataAccess dataAccess2)
        {
            _dataAccess2 = dataAccess2;
        }
        public async Task<IEnumerable<AllTestimonials>> GetAllTestimonials()
    => await _dataAccess2.LoadData<AllTestimonials, dynamic>("sp_GetAllTestimonials", new { });
    }
}
