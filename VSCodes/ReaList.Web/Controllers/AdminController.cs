using Microsoft.AspNetCore.Mvc;
using ReaList.Library.DataAccess.AgentAccount;
using ReaList.Library.DataAccess.Property;
using ReaList.Library.DataAccess.AdminAccount;
using ReaList.Library.Helper;
using ReaList.Library.Model.UserAccounts;
using ReaList.Library.Model.Admin;
using System.Web.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;
using ReaList.Library.Model;
using ReaList.Library.Model.Subscription;
using ReaList.Library.DataAccess.Subscription;
using ReaList.Library.Model.Properties;

namespace ReaList.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISqlDataAccess _db;
        private readonly IAdminAccountDataAccess _dataAccess;
        private readonly IPropertyDataAccess _dataAccessProperty;
        private readonly ISubscriptionDataAccess _dataAccessSubscription;
        private RealistsVM rvm = new RealistsVM();

         public AdminController(ISqlDataAccess db, IAdminAccountDataAccess dataAccess, IPropertyDataAccess dataAccessProperty, ISubscriptionDataAccess dataAccessSubscription )
        {
            _db = db;
            _dataAccess = dataAccess;
            _dataAccessProperty = dataAccessProperty;
            _dataAccessSubscription = dataAccessSubscription;
        }
        [Authorize]
        public async Task<IActionResult> AdminDashboard(AdminAccountModel model)
        {
            
            var AdminID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var parameters = new
            {
                
            };
            rvm.agentAccountsList = await _db.LoadData<AgentAccountModel, dynamic>("sp_GetAllAgentAccount", parameters);
            rvm.customerAccountsList = await _db.LoadData<CustomerAccountModel, dynamic>("sp_GetAllCustomerAccount", parameters);
            rvm.subscriptionList = await _db.LoadData<SubscriptionModel, dynamic>("sp_GetAllSubscription", parameters);
            rvm.subscriptionTypeList = await _db.LoadData<SubscriptionTypeModel, dynamic>("sp_GetAllSubscriptionType", parameters);
            rvm.propertyList = await _db.LoadData<PropertyModel, dynamic>("sp_GetAllProperties", parameters);


            ModelState.Clear();
            return View(rvm);
        
        }
        public async Task<IActionResult> Subscription()
        {

            var parameters = new
            {

            };
            rvm.agentAccountsList = await _db.LoadData<AgentAccountModel, dynamic>("sp_GetAllAgentAccount", parameters);
            rvm.subscriptionList = await _db.LoadData<SubscriptionModel, dynamic>("sp_GetAllSubscription", parameters);
            rvm.subscriptionTypeList = await _db.LoadData<SubscriptionTypeModel, dynamic>("sp_GetAllSubscriptionType", parameters);




            ModelState.Clear();
            return View(rvm);

        }
        [HttpGet]
        public async Task<ActionResult> ForgotPasswordConfirmation(string id)
        {
            AdminAccountModel model = new AdminAccountModel();
            bool status = false;
            var resetCode = new Guid(id);
            try
            {

                string storedProcedureName = "GetUserByResetPasswordCode";


                var parameters = new
                {
                    ResetPasswordCode = resetCode
                };

                // Execute the stored procedure using your ExecuteQuery method
                await _db.ExecuteQuery(storedProcedureName, parameters);

                // If the execution completes without errors, set status to true
                status = true;

                model.ResetPasswordCode = resetCode;

            }
            catch (Exception ex)
            {
                // Handle any exceptions here (e.g., log the error)
                ViewBag.Message = "Error: " + ex.Message;

            }
            ViewBag.Status = status;

            // Conditionally return a view based on the status
            if (status)
            {
                return View(model); // Return a success view
            }
            else
            {
                return View("Error"); // Return an error view
            }

        }
        [HttpPost]
        public async Task<IActionResult> Deactivate(SubscriptionModel model)
        {
            var id = Convert.ToInt32(Request.Form["sub.SubscriptionID"]);
            var SubscriptionID = id;


            model.SubscriptionID = SubscriptionID;

            await _dataAccessSubscription.Unsubscribe(model);
            var parameters = new
            {
              
            };
            rvm.agentAccountsList = await _db.LoadData<AgentAccountModel, dynamic>("sp_GetAllAgentAccount", parameters);
            rvm.subscriptionList = await _db.LoadData<SubscriptionModel, dynamic>("sp_GetAllSubscription", parameters);
            rvm.subscriptionTypeList = await _db.LoadData<SubscriptionTypeModel, dynamic>("sp_GetAllSubscriptionType", parameters);
            return View("Subscription", rvm);

            
        }
        [HttpPost]
        public async Task<IActionResult> Activate(RealistsVM model)
        {
            var id = Convert.ToInt32(Request.Form["sub.SubscriptionID"]);
            var SubscriptionID = id;
            model.subscriptionModel = new SubscriptionModel();

            model.subscriptionModel.SubscriptionID = SubscriptionID;

            await _dataAccessSubscription.ActivateSubscription(model);
            var parameters = new
            {

            };
            model.agentAccountsList = await _db.LoadData<AgentAccountModel, dynamic>("sp_GetAllAgentAccount", parameters);
            model.customerAccountsList = await _db.LoadData<CustomerAccountModel, dynamic>("sp_GetAllCustomerAccount", parameters);
            model.subscriptionList = await _db.LoadData<SubscriptionModel, dynamic>("sp_GetAllSubscription", parameters);
            model.subscriptionTypeList = await _db.LoadData<SubscriptionTypeModel, dynamic>("sp_GetAllSubscriptionType", parameters);
            return View("AdminDashboard", model);


        }


        [HttpPost]
        public async Task<IActionResult> ForgotPasswordConfirmation(AdminAccountModel model)
        {




            var parameters = new
            {
                ResetPasswordCode = model.ResetPasswordCode
            };
            if (await _dataAccess.GetUserByResetCode(model.ResetPasswordCode))
            {
                var param = new { model.ResetPasswordCode };
                // Call the GetUserByResetCode method with the resetPasswordCode from the model.
                var admin = await _db.LoadSingle<AdminAccountModel, dynamic>("sp_GetAdminDataByResetCode", param);
                model.AdminID = admin.AdminID;
                model.Password = Crypto.Hash(model.Password);
                model.ResetPasswordCode = null;

                await _dataAccess.SaveFPassword(model);
                // Now you can work with the result returned from the stored procedure execution.
                // For example, you can iterate through the 'result' to process the data.
            }


            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction("Login", "Login");
        }
        public async Task<ActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserAccountModel model)
        {
            int AdminID = Convert.ToInt32(TempData["id"]);
            var OldPassword = Crypto.Hash(model.OldPassword);
            var NewPassword = Crypto.Hash(model.NewPassword);

            try
            {
                string storedProcedureName = "sp_ValidateAdminPassword";


                var parameters = new
                {
                    AdminID,
                    OldPassword,
                    NewPassword,
                };
                await _db.ExecuteQuery(storedProcedureName, parameters);

                TempData["SuccessMessage"] = "Password Updated!";
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
                return View();
            }



        }



    }
}
