using ReaList.Library.Helper;
using ReaList.Library.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Admin
{
    public interface IAdminAccountDataAccess
    {
        Task<bool> IsEmailExists(string email);
        Task<bool> IsEmailTaken(int id, string email);
        Task Register(AdminAccountModel model);
        Task Save(AdminAccountModel model);
    }
}
