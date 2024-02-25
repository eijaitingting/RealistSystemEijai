using ReaList.Library.Helper;
using ReaList.Library.Model.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Admin
{
    public class AdminAccountDataAccess : IAdminAccountDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public AdminAccountDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> IsEmailExists(string email)
        {
            var data = await _dataAccess.LoadSingle<AdminAccountModel, dynamic>("sp_GetAccountByEmail", new { email });
            return data != null;
        }

        public async Task<bool> IsEmailTaken(int id, string email)
        {
            var data = await _dataAccess.LoadSingle<AdminAccountModel, dynamic>("sp_GetEmailById", new { id, email });
            return data != null;
        }

        public async Task Register(AdminAccountModel model)
        {
            var parameters = new
            {
                model.FirstName,
                model.LastName,
                model.Email,
                model.Password,
                model.DateCreated
            };
            await _dataAccess.ExecuteQuery("sp_AdminRegister", parameters);
        }
        public async Task Save(AdminAccountModel model)
        {
            var parameters = new
            {
                model.FirstName,
                model.LastName,
                model.Email,
                model.Password,
                model.DateUpdated
            };
            await _dataAccess.ExecuteQuery("sp_AdminProfile", parameters);
        }
    }
}
