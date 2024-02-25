using ReaList.Library.Model.Complaints;

namespace ReaList.Library.DataAccess.Complaint
{
    public interface IComplaintDataAccess
    {
        Task<IEnumerable<ComplaintsModel>> GetAllComplaints();
        Task<ComplaintsModel> GetSpecificComplaint(int id);
        Task AddComplaint(ComplaintsModel model);
    }
}
