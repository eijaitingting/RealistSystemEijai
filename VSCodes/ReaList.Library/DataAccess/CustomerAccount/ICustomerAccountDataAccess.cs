using ReaList.Library.Model.Properties;
using ReaList.Library.Model.UserAccounts;

namespace ReaList.Library.DataAccess.CustomerAccount
{
    public interface ICustomerAccountDataAccess
    {
        Task<IEnumerable<CustomerAccountModel>> GetAllCustomerAccount();
        Task<CustomerAccountModel> GetSpecificCustomerAccount(int id);
        Task<bool> IsEmailExists(string email);
        Task<bool> ResetCode(string Email, Guid ResetPasswordCode);
        Task<bool> IsEmailTaken(int id, string email);
        Task RateAgent(CustomerAccountModel model);
        Task Register(CustomerAccountModel model);
        Task Save(CustomerAccountModel model);
        Task SaveFPassword(CustomerAccountModel model);
        Task ResetPassword(int CustomerID, string Password);
        Task<bool> GetUserByResetCode(Guid? resetPasswordCode);

    }
}