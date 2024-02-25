using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReaList.Library.DataAccess.AgentAccount;
using ReaList.Library.DataAccess.Property;
using ReaList.Library.DataAccess.Subscription;
using ReaList.Library.DataAccess.Testimony;
using ReaList.Library.Helper;
using ReaList.Library.Model;
using ReaList.Library.Model.Login;
using ReaList.Library.Model.Properties;
using ReaList.Library.Model.Subscription;
using ReaList.Library.Model.Testimonies;
using ReaList.Library.Model.UserAccounts;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace ReaList.Web.Controllers
{
    public class AgentController : Controller
    {
        private readonly ISqlDataAccess _db;
        private readonly IAgentAccountDataAccess _dataAccess;
        private readonly IPropertyDataAccess _dataAccessProperty;
        private readonly ISubscriptionDataAccess _dataAccessSubscription;
        private readonly ITestimonyDataAccess _dataAccessTestimony;

        public RealistsVM model = new RealistsVM();

        public AgentController(ISqlDataAccess db, IAgentAccountDataAccess dataAccess, IPropertyDataAccess dataAccessProperty, ISubscriptionDataAccess dataAccessSubscription, ITestimonyDataAccess dataAccessTestimony)
        {
            _db = db;
            _dataAccess = dataAccess;
            _dataAccessProperty = dataAccessProperty;
            _dataAccessSubscription = dataAccessSubscription;
            _dataAccessTestimony = dataAccessTestimony;

        }

        [Authorize]
        public async Task<IActionResult> Overview()
        {

            var agentID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var param = new { agentID };
            var agentInfo = await _db.LoginUser<AgentAccountModel, dynamic>("sp_GetSpecificAgentAccount", param);
            model.testimoniesList = (List<TestimoniesModel>)await _dataAccessTestimony.GetAllTestimony();
            model.agentAccountModel = agentInfo;
            //model.agentAccountModel.FirstName = agentInfo.FirstName;
            model.propertyList = (List<PropertyModel>)await _dataAccessProperty.GetAllProperties();




            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> VerifyCode(string id)
        {
            bool status = false;

            try
            {

                string storedProcedureName = "sp_VerifyActivationCodeAgent";


                var parameters = new
                {
                    ActivationCode = new Guid(id)
                };

                // Execute the stored procedure using your ExecuteQuery method
                await _db.ExecuteQuery(storedProcedureName, parameters);

                // If the execution completes without errors, set status to true
                status = true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here (e.g., log the error)
                ViewBag.Message = "Error: " + ex.Message;
            }

            ViewBag.Status = status;
            return View();
        }
        public async Task<IActionResult> Profile(AgentAccountModel model, string message)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var param = new { agentID };
            var agentInfo = await _db.LoginUser<AgentAccountModel, dynamic>("sp_GetSpecificAgentAccount", param);

            if (agentInfo != null)
            {
                model.AgentID = agentInfo.AgentID;
                model.AgentType = agentInfo.AgentType;
                model.FirstName = agentInfo.FirstName;
                model.MiddleName = agentInfo.MiddleName;
                model.LastName = agentInfo.LastName;
                model.Suffix = agentInfo.Suffix;
                model.Birthdate = agentInfo.Birthdate;
                model.Gender = agentInfo.Gender;
                model.Email = agentInfo.Email;
                model.PhoneNumber = agentInfo.PhoneNumber;
                model.Address = agentInfo.Address;
                model.ProfilePicture = agentInfo.ProfilePicture;
                model.LicenseIdNumber = agentInfo.LicenseIdNumber;
                model.AgentAbout = agentInfo.AgentAbout;
                model.CompanyName = agentInfo.CompanyName;
                model.Education = agentInfo.Education;
                model.Organizations = agentInfo.Organizations;
            }

            ViewData["showid"] = model.AgentID;
            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProfile(AgentAccountModel model)
        {
            if (!await _dataAccess.IsEmailTaken(model.AgentID, model.Email))
            {
                if (await _dataAccess.IsEmailExists(model.Email))
                {
                    var errorMessage = "Email is already taken!";
                    ModelState.AddModelError("Email", errorMessage);
                    return RedirectToAction("Profile", new { message = errorMessage });
                }
            }

            if (model.ProfilePictureImage != null)
            {
                string[] allowed = { ".jpg", ".jpeg", ".png", ".gif" }; // Add more extensions if needed

                // Check if the uploaded file's extension is in the list of allowed extensions
                var extension = Path.GetExtension(model.ProfilePictureImage.FileName).ToLowerInvariant();
                if (!allowed.Contains(extension))
                {
                    var errorMessage = "\"Only JPG, JPEG, PNG, and GIF files are allowed.\"";
                    // Handle error - return or throw an exception with an appropriate error message
                    ModelState.AddModelError("ProfilePictureImage", errorMessage);
                    // You may choose to return the current view or handle the error in another way
                    return RedirectToAction("Profile", new { message = errorMessage }); // Assuming you are in a controller action method
                }
                var fileName = Guid.NewGuid().ToString() + "_" + model.ProfilePictureImage.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles", fileName);
                Debug.WriteLine(filePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create)) { await model.ProfilePictureImage.CopyToAsync(fileStream); }

                model.ProfilePicture = fileName;
            }

            await _dataAccess.Save(model);
            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public async Task<ActionResult> ForgotPasswordConfirmation(string id)
        {
            AgentAccountModel model = new AgentAccountModel();
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
        public async Task<IActionResult> ForgotPasswordConfirmation(AgentAccountModel model)
        {




            var parameters = new
            {
                ResetPasswordCode = model.ResetPasswordCode
            };
            if (await _dataAccess.GetUserByResetCode(model.ResetPasswordCode))
            {
                var param = new { model.ResetPasswordCode };
                // Call the GetUserByResetCode method with the resetPasswordCode from the model.
                var agent = await _db.LoadSingle<AgentAccountModel, dynamic>("sp_GetAgentDataByResetCode", param);
                model.AgentID = agent.AgentID;
                model.Password = Crypto.Hash(model.Password);
                model.ResetPasswordCode = null;

                await _dataAccess.SaveFPassword(model);
                // Now you can work with the result returned from the stored procedure execution.
                // For example, you can iterate through the 'result' to process the data.
            }


            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction("Login", "Login");
        }
        [HttpGet]
        public async Task<ActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserAccountModel model)
        {
            int AgentID = Convert.ToInt32(TempData["id"]);
            var OldPassword = Crypto.Hash(model.OldPassword);
            var NewPassword = Crypto.Hash(model.NewPassword);

            try
            {
                string storedProcedureName = "sp_ValidateAgentPassword";


                var parameters = new
                {
                    AgentID,
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
        public async Task<IActionResult> Subscription()
        {
            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var param = new { agentID };
            var agentInfo = await _db.LoginUser<AgentAccountModel, dynamic>("sp_GetSpecificAgentAccount", param);
            model.agentAccountModel = agentInfo;

            model.subscriptionList = (List<SubscriptionModel>)await _dataAccessSubscription.GetAllSubscription();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Unsubscribe(SubscriptionModel model)
        {
            var id = Convert.ToInt32(Request.Form["sub.SubscriptionID"]);
            var SubscriptionID = id;

           
            model.SubscriptionID = SubscriptionID;

            await _dataAccessSubscription.Unsubscribe(model);

            return View("Subscription", model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveReference(RealistsVM model)
        {
        
            var fileName = Guid.NewGuid().ToString() + "_" + model.subscriptionModel.SubPhotoImage.FileName;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles", fileName);
            Debug.WriteLine(filePath);

            using (var fileStream = new FileStream(filePath, FileMode.Create)) { await model.subscriptionModel.SubPhotoImage.CopyToAsync(fileStream); }
            model.subscriptionModel = new SubscriptionModel();
            model.subscriptionModel.SubPhoto = fileName;

            var refnum = model.subscriptionModel.ReferenceNumber;
            
            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
           
            model.subscriptionModel.SubscriptionTypeID = 2;
            model.subscriptionModel.AgentID = agentID;
            model.subscriptionModel.ReferenceNumber = refnum;
            //model.subscriptionModel.SubPhoto = subphoto;
           


            await _dataAccessSubscription.SaveReference(model);

            return View("Subscription",model);
        }
    } 
}