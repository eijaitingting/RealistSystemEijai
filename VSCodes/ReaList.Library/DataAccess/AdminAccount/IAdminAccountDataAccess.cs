using ReaList.Library.Model.UserAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.AdminAccount
{
    public interface IAdminAccountDataAccess
    {
        Task<bool> ResetCode(string Email, Guid ResetPasswordCode);
        Task<bool> GetUserByResetCode(Guid? resetPasswordCode);
        Task SaveFPassword(AdminAccountModel model);
    }
}
