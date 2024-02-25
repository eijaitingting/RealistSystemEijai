using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReaList.Library.DataAccess.AgentAccount;
using ReaList.Library.DataAccess.CustomerAccount;
using ReaList.Library.Helper;
using ReaList.Library.Model.UserAccounts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Web.Helpers;

namespace ReaList.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ISqlDataAccess _db;
        private readonly ICustomerAccountDataAccess _dataAccess;

        public CustomerController(ISqlDataAccess db, ICustomerAccountDataAccess dataAccess)
        {
            _db = db;
            _dataAccess = dataAccess;
        }

        [Authorize]
        public async Task<IActionResult> Home(CustomerAccountModel model)
        {
            var customerID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var param = new { customerID };
            var customerInfo = await _db.LoginUser<CustomerAccountModel, dynamic>("sp_GetSpecificCustomerAccount", param);
            model.CustomerID = customerInfo.CustomerID;
            model.FirstName = customerInfo.FirstName;

            ViewData["CustomerID"] = model.FirstName;
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserAccountModel model)
        {
            int CustomerID = Convert.ToInt32(TempData["id"]);
            var OldPassword = Crypto.Hash(model.OldPassword);
            var NewPassword = Crypto.Hash(model.NewPassword);
       
            try
            {
                string storedProcedureName = "sp_ValidateCustomerPassword";


                var parameters = new
                {
                    CustomerID,
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
            [HttpGet]
        public async Task<ActionResult> ForgotPasswordConfirmation(string id)
        {
            CustomerAccountModel model = new CustomerAccountModel();
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
        public async Task<IActionResult> ForgotPasswordConfirmation(CustomerAccountModel model)
        {

        


            var parameters = new
            {
                ResetPasswordCode = model.ResetPasswordCode
            };
            if (await _dataAccess.GetUserByResetCode(model.ResetPasswordCode))
            {
                var param = new { model.ResetPasswordCode };
                // Call the GetUserByResetCode method with the resetPasswordCode from the model.
               var customer = await _db.LoadSingle<CustomerAccountModel, dynamic>("sp_GetCustomerDataByResetCode", param);
                model.CustomerID = customer.CustomerID;
                model.Password = Crypto.Hash(model.Password);
                model.ResetPasswordCode = null;

                await _dataAccess.SaveFPassword(model);
                // Now you can work with the result returned from the stored procedure execution.
                // For example, you can iterate through the 'result' to process the data.
            }

          
            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction("Login","Login");
        }
        [HttpGet]
        public async Task<ActionResult> VerifyCode(string id)
        {
            bool status = false;

            try
            {

                string storedProcedureName = "sp_VerifyActivationCodeCustomer";


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
        public async Task<IActionResult> Profile(CustomerAccountModel model, string message)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            var customerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var param = new { customerID };
            var customerInfo = await _db.LoginUser<CustomerAccountModel, dynamic>("sp_GetSpecificCustomerAccount", param);
            model.CustomerID = customerInfo.CustomerID;
            model.FirstName = customerInfo.FirstName;
            model.LastName = customerInfo.LastName;
            model.Birthdate = customerInfo.Birthdate;
            model.Email = customerInfo.Email;
            model.PhoneNumber = customerInfo.PhoneNumber;
            model.Address = customerInfo.Address;
            model.ProfilePicture = customerInfo.ProfilePicture;

            ViewData["showid"] = model.CustomerID;
            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProfile(CustomerAccountModel model)
        {
            if (!await _dataAccess.IsEmailTaken(model.CustomerID, model.Email))
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

        public IActionResult RateAgent(CustomerAccountModel model, int bookingID, int agentID)
        {
            model.BookingID = bookingID;
            model.AgentID = agentID;
            
            var customerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.CustomerID = customerID;
            
            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRatings(CustomerAccountModel model)
        {
            await _dataAccess.RateAgent(model);
            TempData["SuccessMessage"] = "Thank you for your ratings!";
            return RedirectToAction("Bookings", "Booking");
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public async Task<IActionResult> ContactUs(CustomerAccountModel model, string message)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            var customerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var param = new { customerID };
            var customerInfo = await _db.LoginUser<CustomerAccountModel, dynamic>("sp_GetSpecificCustomerAccount", param);
            model.FirstName = customerInfo.FirstName;
            model.LastName = customerInfo.LastName;
            model.Email = customerInfo.Email;

            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(CustomerAccountModel model)
        {
            model.Name = model.FirstName + " " + model.LastName;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("kiradiel12@gmail.com");
                mail.To.Add("kimberlyfranczeska.iradiel@benilde.edu.ph");
                mail.Subject = "Contact Form Submission";
                mail.Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}";

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("kiradiel12@gmail.com", "lee3jong4suk3");

                    try
                    {
                        await smtpClient.SendMailAsync(mail);
                        TempData["SuccessMessage"] = "Your message has been sent!";
                    }
                    catch (SmtpException ex)
                    {
                        TempData["ErrorMessage"] = "An error occurred while sending the email.";
                    }
                }
            }

            return RedirectToAction("ContactUs");
        }

    }
}
