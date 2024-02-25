using ReaList.Library.Helper;
using ReaList.Library.Model.Testimonies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Testimony
{
    public class TestimonyDataAccess : ITestimonyDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public TestimonyDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<TestimoniesModel>> GetAllTestimony()
            => await _dataAccess.LoadData<TestimoniesModel, dynamic>("sp_GetAllComplaints", new { });
        public async Task<TestimoniesModel> GetSpecificTestimony(int id)
            => await _dataAccess.LoadSingle<TestimoniesModel, dynamic>("sp_GetSpecificComplaint", new { id });

        public async Task AddTestimony(TestimoniesModel model)
        {
            var parameters = new
            {
                model.TestimonyID,
                model.AgentID,
                model.Testimony,
                model.isDisplayed,
                model.DateCreated
            };
            await _dataAccess.ExecuteQuery("sp_AddTestimony", parameters);
        }
    }
}