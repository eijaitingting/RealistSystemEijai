using ReaList.Library.Helper;
using ReaList.Library.Model.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Subscriptions
{
    public class GetAllSubscriptionDataAccess : IGetAllSubscriptionDataAccess
    {
        private readonly ISqlDataAccess _dataAccess5;
        public GetAllSubscriptionDataAccess(ISqlDataAccess dataAccess5)
        {
            _dataAccess5 = dataAccess5;
        }
        public async Task<IEnumerable<AllSubscriptions>> GetAllSubscriptions()
    => await _dataAccess5.LoadData<AllSubscriptions, dynamic>("sp_GetAllSubscription", new { });
    }
}
