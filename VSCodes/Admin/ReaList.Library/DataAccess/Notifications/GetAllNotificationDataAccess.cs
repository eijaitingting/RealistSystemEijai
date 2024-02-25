using ReaList.Library.Helper;
using ReaList.Library.Model.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Notifications
{
    public class GetAllNotificationDataAccess : IGetAllNotificationDataAccess
    {
        private readonly ISqlDataAccess _dataAccess6;
        public GetAllNotificationDataAccess(ISqlDataAccess dataAccess6)
        {
            _dataAccess6 = dataAccess6;
        }
        public async Task<IEnumerable<AllNotifications>> GetAllNotifications()
    => await _dataAccess6.LoadData<AllNotifications, dynamic>("sp_GetAllNotifications", new { });
    }
}
