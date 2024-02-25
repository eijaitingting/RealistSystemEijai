using Microsoft.EntityFrameworkCore;
using ReaList.Library.Helper;
using ReaList.Library.Model.UserAccounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.AdminAccount
{
    public class AdminAccountDataAccess : IAdminAccountDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public AdminAccountDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<bool> ResetCode(string Email, Guid ResetPasswordCode)
        {
            var data = await _dataAccess.LoadSingle<AdminAccountModel, dynamic>("sp_UpdateAdminResetCode", new { Email, ResetPasswordCode });
            var data1 = await _dataAccess.LoadSingle<AdminAccountModel, dynamic>("sp_GetAdminDataByResetCode", new { ResetPasswordCode });
            if (data1 == null)
            {
                return data == null;
            }
            else
            {
                return data != null;
            }

        }
        public async Task<bool> GetUserByResetCode(Guid? resetPasswordCode)
        {
            // Use the resetPasswordCode parameter in your stored procedure execution.
            // Return true if the user exists, and false otherwise.
            var result = await _dataAccess.LoadData<AdminAccountModel, dynamic>("GetUserByResetPasswordCode", new { ResetPasswordCode = resetPasswordCode });

            // Check if the result indicates that the user exists.
            return result != null && result.Any(); // Adjust this based on your data retrieval logic.
        }
        public async Task SaveFPassword(AdminAccountModel model)
        {
            var parameters = new
            {
                model.AdminID,
                model.Password,
                model.ResetPasswordCode

            };
            await _dataAccess.ExecuteQuery("sp_UpdateAdminPassword", parameters);
        }
    }
}
