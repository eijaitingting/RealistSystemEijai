using Microsoft.AspNetCore.Mvc;
using ReaList.Library.DataAccess.Testimony;
using ReaList.Library.Model.Testimonies;
using System.Security.Claims;

namespace ReaList.Web.Controllers
{
    public class TestimonyController : Controller
    {
        private readonly ITestimonyDataAccess _dataAccess;

        public TestimonyController(ITestimonyDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult AddTestimony(TestimoniesModel model, string message)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.AgentID = agentID;

            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveTestimony(TestimoniesModel model)
        {
            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.AgentID = agentID;

            await _dataAccess.AddTestimony(model);
            TempData["SuccessMessage"] = "Testimony Submitted Successfully!";
            return RedirectToAction("AddTestimony");
        }
    }
}
