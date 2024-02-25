using Microsoft.EntityFrameworkCore;
using ReaList.Library.Helper;
using ReaList.Library.Model.Subscription;
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

namespace ReaList.Library.DataAccess.AgentAccount
{
    public class AgentAccountDataAccess : IAgentAccountDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public AgentAccountDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
    
        #region Getter
        public async Task<IEnumerable<AgentAccountModel>> GetAllAgentAccount() 
            => await _dataAccess.LoadData<AgentAccountModel, dynamic>("sp_GetAllAgentAccount", new { });
        public async Task<AgentAccountModel> GetSpecificAgentAccount(int id) 
            => await _dataAccess.LoadSingle<AgentAccountModel, dynamic>("sp_GetSpecificAgentAccount", new { id });
        #endregion

        public async Task<bool> IsEmailExists(string email)
        {
            var data = await _dataAccess.LoadSingle<AgentAccountModel, dynamic>("sp_GetAccountByEmail", new { email });
            return data != null;
        }

        public async Task<bool> IsEmailTaken(int id, string email)
        {
            var data = await _dataAccess.LoadSingle<AgentAccountModel, dynamic>("sp_GetEmailById", new { id, email });
            return data != null;
        }

        public async Task Register(AgentAccountModel model)
        {
            //Insert Agents Table
            var parameters = new
            {
                model.AgentID,
                model.FirstName,
                model.LastName,
                model.Email,
                model.Password,
                model.ActivationCode,
                model.IsEmailVerified,
                model.AccountStatus,
                model.isVerified,
                model.DateCreated
            };
            await _dataAccess.ExecuteQuery("sp_AgentRegister", parameters);
        }

        public async Task Save(AgentAccountModel model)
        {
            //Insert Agents Profile
            var parameters = new
            {
                model.AgentID,
                model.AgentType,
                model.FirstName,
                model.MiddleName,
                model.LastName,
                model.Suffix,
                model.Birthdate,
                model.Gender,
                model.PhoneNumber,
                model.Email,
                model.Address,
                model.ProfilePicture,
                model.AgentAbout,
                model.CompanyName,
                model.Education,
                model.Organizations,
                model.LicenseIdNumber,
                model.DateUpdated
            };
            await _dataAccess.ExecuteQuery("sp_AgentProfile", parameters);
        }

        public async Task<bool> ResetCode(string Email, Guid ResetPasswordCode)
        {
            var data = await _dataAccess.LoadSingle<AgentAccountModel, dynamic>("sp_UpdateAgentResetCode", new { Email, ResetPasswordCode });
            var data1 = await _dataAccess.LoadSingle<AgentAccountModel, dynamic>("sp_GetAgentDataByResetCode", new { ResetPasswordCode });
            if (data1== null)
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
            var result = await _dataAccess.LoadData<AgentAccountModel, dynamic>("GetUserByResetPasswordCode", new { ResetPasswordCode = resetPasswordCode });

            // Check if the result indicates that the user exists.
            return result != null && result.Any(); // Adjust this based on your data retrieval logic.
        }
        public async Task SaveFPassword(AgentAccountModel model)
        {
            var parameters = new
            {
                model.AgentID,
                model.Password,
                model.ResetPasswordCode

            };
            await _dataAccess.ExecuteQuery("sp_UpdateAgentPassword", parameters);
        }
     
    }
}
