using ReaList.Library.Model.UserAccounts;

namespace ReaList.Library.DataAccess.AgentAccount
{
    public interface IAgentAccountDataAccess
    {
        Task<IEnumerable<AgentAccountModel>> GetAllAgentAccount();
        Task<AgentAccountModel> GetSpecificAgentAccount(int id);
        Task<bool> IsEmailExists(string email);
        Task<bool> IsEmailTaken(int id, string email);
        Task Register(AgentAccountModel model);
        Task Save(AgentAccountModel model);
        Task<bool> ResetCode(string Email, Guid ResetPasswordCode);
        Task<bool> GetUserByResetCode(Guid? resetPasswordCode);
        Task SaveFPassword(AgentAccountModel model);
    }
}