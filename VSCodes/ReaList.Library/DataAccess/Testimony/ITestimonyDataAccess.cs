using ReaList.Library.Model.Complaints;
using ReaList.Library.Model.Testimonies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Testimony
{
    public interface ITestimonyDataAccess
    {
        Task<IEnumerable<TestimoniesModel>> GetAllTestimony();
        Task<TestimoniesModel> GetSpecificTestimony(int id);
        Task AddTestimony(TestimoniesModel model);
    }
}
