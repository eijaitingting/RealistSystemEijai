using ReaList.Library.Helper;
using ReaList.Library.Model;
using ReaList.Library.Model.Subscription;

namespace ReaList.Library.DataAccess.Subscription
{
    public class SubscriptionDataAccess : ISubscriptionDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public SubscriptionDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task Unsubscribe(SubscriptionModel model)
        {
            var parameters = new
            {
                model.SubscriptionID
            
            };
            await _dataAccess.ExecuteQuery("sp_UpdateSubscription", parameters);
        }
        public async Task SaveReference(RealistsVM model)
        {
            var parameters = new
            {
                model.subscriptionModel.SubscriptionTypeID,
                model.subscriptionModel.AgentID,
                model.subscriptionModel.ReferenceNumber,
                model.subscriptionModel.SubPhoto,
                

            };
            await _dataAccess.ExecuteQuery("sp_AddNewSubscription", parameters);
        }
        public async Task ActivateSubscription(RealistsVM model)
        {
            var parameters = new
            {
                model.subscriptionModel.SubscriptionID


            };
            await _dataAccess.ExecuteQuery("sp_ActivateSubscription", parameters);
        }
        public async Task<IEnumerable<SubscriptionModel>> GetAllSubscription()
            => await _dataAccess.LoadData<SubscriptionModel, dynamic>("sp_GetAllSubscription", new { });
     
    }
}
