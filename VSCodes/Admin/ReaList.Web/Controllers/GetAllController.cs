using Microsoft.AspNetCore.Mvc;
using ReaList.Library.DataAccess.Agents;
using ReaList.Library.DataAccess.Complaints;
using ReaList.Library.DataAccess.Customers;
using ReaList.Library.DataAccess.Notifications;
using ReaList.Library.DataAccess.Properties;
using ReaList.Library.DataAccess.Subscriptions;
using ReaList.Library.DataAccess.Testimonials;
using ReaList.Library.Model.Pages;

namespace ReaList.Web.Controllers
{
    public class GetAllController :Controller
    {
        private readonly IGetAllAgentDataAccess _dataAccess;
        private readonly IGetAllCustomersDataAccess _dataAccess1;
        private readonly IGetAllComplaintDataAccess _dataAccess2;
        private readonly IGetAllTestimonialDataAccess _dataAccess3;
        private readonly IGetAllPropertiesDataAccess _dataAccess4;
        private readonly IGetAllSubscriptionDataAccess _dataAccess5;
        private readonly IGetAllNotificationDataAccess _dataAccess6;

        public GetAllController(IGetAllAgentDataAccess dataAccess, IGetAllCustomersDataAccess dataAccess1,
            IGetAllComplaintDataAccess dataAccess2,
            IGetAllTestimonialDataAccess dataAccess3, IGetAllPropertiesDataAccess dataAccess4, IGetAllSubscriptionDataAccess dataAccess5,
            IGetAllNotificationDataAccess dataAccess6)


        {
            _dataAccess = dataAccess;
            _dataAccess1 = dataAccess1;
            _dataAccess2 = dataAccess2;
            _dataAccess3 = dataAccess3;
            _dataAccess4 = dataAccess4;
            _dataAccess5 = dataAccess5;
            _dataAccess6 = dataAccess6;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAgent() => Ok(await _dataAccess.GetAllAgentAccount());
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer() => Ok(await _dataAccess1.GetAllCustomerAccount());
        [HttpGet]
        public async Task<IActionResult> GetAllComplaint() => Ok(await _dataAccess2.GetAllComplaints());
        [HttpGet]
        public async Task<IActionResult> GetAllTestimonial() => Ok(await _dataAccess3.GetAllTestimonials());
        [HttpGet]
        public async Task<IActionResult> GetAllReviewProperty() => Ok(await _dataAccess4.GetAllReviewProperties());
        public async Task<IActionResult> GetAllSubscription() => Ok(await _dataAccess5.GetAllSubscriptions());
        public async Task<IActionResult> GetAllNotification() => Ok(await _dataAccess6.GetAllNotifications());

        public async Task<IActionResult> BanAccount(AllAgents model)
        {
            model.AccountStatus = 4;
            TempData["SuccessMessage"] = "Banned an Account";
            return View(model);

        }
        public async Task<IActionResult> DeactivateAccount(AllAgents model)
        {
            model.AccountStatus = 3;
            TempData["SuccessMessage"] = "Deactivated an Account";
            return View(model);

        }
    }
}
