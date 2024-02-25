using ReaList.Library.DataAccess.Testimony;
using ReaList.Library.Helper;
using ReaList.Library.Model;
using ReaList.Library.Model.Bookings;
using ReaList.Library.Model.Subscription;
using ReaList.Library.Model.Testimonies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Subscription
{
    public interface ISubscriptionDataAccess
    {
        Task<IEnumerable<SubscriptionModel>> GetAllSubscription();
        Task Unsubscribe(SubscriptionModel model);
        Task SaveReference(RealistsVM model);
        Task ActivateSubscription(RealistsVM model);
    }
}