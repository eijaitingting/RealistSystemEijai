using Microsoft.EntityFrameworkCore;
using ReaList.Library.Helper;
using ReaList.Library.Model.Complaints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Complaint
{
    public class ComplaintDataAccess : IComplaintDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public ComplaintDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<ComplaintsModel>> GetAllComplaints()
              => await _dataAccess.LoadData<ComplaintsModel, dynamic>("sp_GetAllComplaints", new { });
        
        public async Task<ComplaintsModel> GetSpecificComplaint(int id)
            => await _dataAccess.LoadSingle<ComplaintsModel, dynamic>("sp_GetSpecificComplaint", new { id });

        public async Task AddComplaint(ComplaintsModel model)
        {
            var parameters = new
            {
                model.ComplaintID,
                model.AgentID,
                model.CustomerID,
                model.ComplaintCategory,
                model.DateOfEvent,
                model.ComplaintSubject,
                model.ComplaintDetails,
                /*model.ComplaintImages,*/
                model.ComplaintStatus,
                model.DateCreated
            };
            await _dataAccess.ExecuteQuery("sp_AddComplaint", parameters);
        }
    }
}
