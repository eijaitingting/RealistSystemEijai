
using ReaList.Library.Helper;
using ReaList.Library.Model.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Complaints
{
    public class GetAllComplaintDataAccess : IGetAllComplaintDataAccess
    {
        private readonly ISqlDataAccess _dataAccess3;
        public GetAllComplaintDataAccess(ISqlDataAccess dataAccess3)
        {
            _dataAccess3 = dataAccess3;
        }
        public async Task<IEnumerable<AllComplaints>> GetAllComplaints()
    => await _dataAccess3.LoadData<AllComplaints, dynamic>("sp_GetAllComplaints", new { });
    }
}
