using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaList.Library.Helper;
using System.Security.Claims;
using ReaList.Library.DataAccess.AgentAccount;
using ReaList.Library.Model.Login;
using ReaList.Library.DataAccess.CustomerAccount;
using ReaList.Library.Model.UserAccounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Web.Helpers;

namespace ReaList.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISqlDataAccess _db;
        private readonly IAgentAccountDataAccess _dataAccess;
        private readonly ICustomerAccountDataAccess _dataAccess1;

        public LoginController(ISqlDataAccess db, IAgentAccountDataAccess dataAccess, ICustomerAccountDataAccess dataAccess1)
        {
            _db = db;
            _dataAccess = dataAccess;
            _dataAccess1 = dataAccess1;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl, string message)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
                return RedirectToLocal(returnUrl);

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(AgentLoginModel model, CustomerLoginModel model1,AdminLoginModel adminmodel)
        { 
            var Password = Crypto.Hash(model.Password);
            var AdminPass = model.Password;
           
            var isEmailVerified = "true";
            var parameter = new { model.Email, Password, isEmailVerified};
            var parameter1 = new { model1.Email, Password, isEmailVerified };
            var adminparameter = new { model1.Email, Password };

            var agentLogin = await _db.LoginUser<AgentLoginModel, dynamic>("sp_AgentLogin", parameter);
            var customerLogin = await _db.LoginUser<CustomerLoginModel, dynamic>("sp_CustomerLogin", parameter1);
            var adminLogin = await _db.LoginUser<AdminLoginModel, dynamic>("sp_AdminLogin", adminparameter);

            if (agentLogin != null)
            {
                var userRole = "Agent";
                model.AgentID = agentLogin.AgentID;

                await SignInUserAsync(userRole, model.AgentID);
                TempData["id"] = model.AgentID;
                return RedirectToAction("Overview", "Agent");
            }

            if (customerLogin != null)
            {
                var userRole = "Customer";
                model1.CustomerID = customerLogin.CustomerID;
                TempData["id"] = model1.CustomerID;
                await SignInUserAsync(userRole, model1.CustomerID);

                return RedirectToAction("Home", "Customer");
            }
            if (adminLogin != null)
            {
                var userRole = "Admin";
                adminmodel.AdminID = adminLogin.AdminID;
                TempData["id"] = adminmodel.AdminID;
                await SignInUserAsync(userRole, adminmodel.AdminID);

                return RedirectToAction("AdminDashboard", "Admin");
            }

            var errorMessage = "Your account is not yet verified.";
            ModelState.AddModelError("Invalid", errorMessage);
            return RedirectToAction("Login", new { message = errorMessage });
        }

        [HttpGet]
        private async Task SignInUserAsync(string userRole, int userID)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userID.ToString()),
                    new Claim(ClaimTypes.Role, userRole),
                    new Claim("Role", userRole)
                };

                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);
            }
            catch (Exception) { throw; }
        }

        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception) { throw; }
            return RedirectToAction("Login", "Login");
        }

        [AllowAnonymous]
        private IActionResult RedirectToLocal(string returnUrl)
        {   
            try
            {
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
