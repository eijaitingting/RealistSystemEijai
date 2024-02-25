using Microsoft.AspNetCore.Mvc;
using ReaList.Library.DataAccess.Admin;
using ReaList.Library.Model.Admin;

namespace ReaList.Web.Controllers
{
    public class AdminAccountController : Controller
    {
        private readonly IAdminAccountDataAccess _dataAccess;

        public AdminAccountController(IAdminAccountDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Register(AdminAccountModel model, string message)
        {
            if (ModelState.IsValid)
            {
                model.AdminID = model.AdminID;
                return View();
            }

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            ModelState.Clear();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(AdminAccountModel model)
        {
            if (await _dataAccess.IsEmailExists(model.Email))
            {
                var errorMessage = "Registration Failed. Email already exists!";
                ModelState.AddModelError("Email", errorMessage);
                return RedirectToAction("Register", "AdminAccount", new { message = errorMessage });
            }

            await _dataAccess.Register(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
