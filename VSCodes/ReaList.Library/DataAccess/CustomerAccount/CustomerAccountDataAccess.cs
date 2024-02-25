using Microsoft.EntityFrameworkCore;
using ReaList.Library.Helper;
using ReaList.Library.Model.Properties;
using ReaList.Library.Model.UserAccounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.CustomerAccount
{
    public class CustomerAccountDataAccess : ICustomerAccountDataAccess
    {
        private readonly ISqlDataAccess _dataAccess1;
        public CustomerAccountDataAccess(ISqlDataAccess dataAccess1)
        {
            _dataAccess1 = dataAccess1;
        }

        #region Getter
        public async Task<IEnumerable<CustomerAccountModel>> GetAllCustomerAccount()
            => await _dataAccess1.LoadData<CustomerAccountModel, dynamic>("sp_GetAllCustomerAccount", new { });
        public async Task<CustomerAccountModel> GetSpecificCustomerAccount(int id)
            => await _dataAccess1.LoadSingle<CustomerAccountModel, dynamic>("sp_GetSpecificCustomerAccount", new { id });
        #endregion

        public async Task<bool> IsEmailExists(string email)
        {
            var data = await _dataAccess1.LoadSingle<CustomerAccountModel, dynamic>("sp_GetAccountByEmail", new { email });
            return data != null;
        }

        public async Task<bool> IsEmailTaken(int id, string email)
        {
            var data = await _dataAccess1.LoadSingle<AgentAccountModel, dynamic>("sp_GetEmailById", new { id, email });
            return data != null;
        }
        public async Task<bool> ResetCode(string Email,Guid ResetPasswordCode)
        {
            var data = await _dataAccess1.LoadSingle<CustomerAccountModel, dynamic>("sp_UpdateCustomerResetCode", new { Email, ResetPasswordCode });
            var data1 = await _dataAccess1.LoadSingle<CustomerAccountModel, dynamic>("sp_GetCustomerDataByResetCode", new { ResetPasswordCode });
        
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
            var result = await _dataAccess1.LoadData<CustomerAccountModel, dynamic>("GetUserByResetPasswordCode", new { ResetPasswordCode = resetPasswordCode });

            // Check if the result indicates that the user exists.
            return result != null && result.Any(); // Adjust this based on your data retrieval logic.
        }
    
        public async Task Register(CustomerAccountModel model)
        {
            //Insert Customers Table
            var parameters = new
            {
                model.CustomerID,
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
            await _dataAccess1.ExecuteQuery("sp_CustomerRegister", parameters);
        }

        public async Task Save(CustomerAccountModel model)
        {
            var parameters = new
            {
                model.CustomerID,
                model.FirstName,
                model.LastName,
                model.Birthdate,
                model.PhoneNumber,
                model.Email,
                model.Address,
                model.ProfilePicture,
                model.DateUpdated
            };
            await _dataAccess1.ExecuteQuery("sp_CustomerProfile", parameters);
        }
        public async Task SaveFPassword(CustomerAccountModel model)
        {
            var parameters = new
            {
                model.CustomerID,
                model.Password,
                model.ResetPasswordCode
             
            };
            await _dataAccess1.ExecuteQuery("sp_UpdateCustomerPassword", parameters);
        }
        public async Task ResetPassword(int CustomerID, string Password)
        {
            var parameters = new
            {
               CustomerID,Password

            };
            await _dataAccess1.ExecuteQuery("sp_ValidateCustomerPassword", parameters);
        }
        public async Task RateAgent(CustomerAccountModel model)
        {
            var parameters = new
            {
                model.AgentRatingsID,
                model.BookingID,
                model.AgentID,
                model.CustomerID,
                model.AgentRatings,
                model.Feedback,
                model.DateCreated
            };
            await _dataAccess1.ExecuteQuery("sp_AddAgentRating", parameters);
        }
    }
}