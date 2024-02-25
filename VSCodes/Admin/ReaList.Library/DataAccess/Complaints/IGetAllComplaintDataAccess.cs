using ReaList.Library.Model.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Complaints
{
    public interface IGetAllComplaintDataAccess
    {
        Task<IEnumerable<AllComplaints>> GetAllComplaints();
    }
}
