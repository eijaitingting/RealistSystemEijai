using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaList.Library.DataAccess.Admin;
using ReaList.Library.Helper;
using ReaList.Library.Model.Login;
using System.Security.Claims;
using System.Security.Policy;

namespace ReaList.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISqlDataAccess _db;
        private readonly IAdminAccountDataAccess _dataAccess;

        public LoginController(ISqlDataAccess db, IAdminAccountDataAccess dataAccess)
        {
            _db = db;
            _dataAccess = dataAccess;
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

        [HttpPost]
        public async Task<IActionResult> Login(AdminLogin model)
        {
            var parameter = new { model.Email, model.Password };

            var AdminLogin = await _db.LoginUser<AdminLogin, dynamic>("sp_AdminLogin", parameter);
            if (AdminLogin != null)
            {
                
                model.AdminID = AdminLogin.AdminID;

                return RedirectToAction("Privacy", "Home");
            }

            var errorMessage = "Invalid login attempt.";
            ModelState.AddModelError("Invalid", errorMessage);
            return RedirectToAction("Login", new { message = errorMessage });
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
