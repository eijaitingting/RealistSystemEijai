using ReaList.Library.Model.Properties;
using ReaList.Library.Model.UserAccounts;
using ReaList.Library.Model.Testimonies;
using ReaList.Library.Model.Subscription;
//using ReaList.Library.Model.AgentRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model
{
    public class RealistsVM
    {
        public AgentAccountModel agentAccountModel { get; set; }
        public List<AgentAccountModel> agentAccountsList { get; set; }
        public CustomerAccountModel customerAccountModel { get; set; }
        public List<CustomerAccountModel> customerAccountsList { get; set; }
        public PropertyModel propertyModel { get; set; }
        public List<PropertyModel> propertyList { get; set; }

        public TestimoniesModel testimoniesModel { get; set; }
        public List<TestimoniesModel> testimoniesList { get; set; }
        public SubscriptionModel subscriptionModel { get; set; }
        public List<SubscriptionModel> subscriptionList { get; set; }
        public SubscriptionTypeModel subscriptionTypeModel { get; set; }
        public List<SubscriptionTypeModel> subscriptionTypeList { get; set; }

        //public AgentRatingModel agentRating { get; set; }
        //public List<AgentRatingModel> agentRatingList { get; set; }

    }
}
