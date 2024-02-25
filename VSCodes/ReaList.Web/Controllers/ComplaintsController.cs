using Microsoft.AspNetCore.Mvc;
using ReaList.Library.DataAccess.Complaint;
using ReaList.Library.Helper;
using ReaList.Library.Model.Complaints;
using ReaList.Library.Model.UserAccounts;
using System.Globalization;
using System.Security.Claims;

namespace ReaList.Web.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly ISqlDataAccess _db;
        private readonly IComplaintDataAccess _dataAccess;

        public ComplaintsController(ISqlDataAccess db, IComplaintDataAccess dataAccess)
        {
            _db = db;
            _dataAccess = dataAccess;
        }

        public async Task<IActionResult> Complaints(ComplaintsModel model)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var param = new { agentID };
            var agentComplaints = await _db.LoadData<ComplaintsModel, dynamic>("sp_GetAllComplaintsByAgent", param);

            var complaintList = new List<ComplaintsModel>();

            foreach (var complaint in agentComplaints)
            {
                var ComplaintID = complaint.ComplaintID;
                var AgentID = complaint.AgentID;
                var CustomerID = complaint.CustomerID;
                var DateOfEvent = complaint.DateOfEvent;
                var ComplaintSubject = complaint.ComplaintSubject;
                var ComplaintDetails = complaint.ComplaintDetails;
                var DateCreated = complaint.DateCreated;

                if (complaint.ComplaintCategory == 1)
                    model.ComplaintCategoryName = "Complain about a Customer";
                if (complaint.ComplaintCategory == 2)
                    model.ComplaintCategoryName = "Complain about an Agent";
                if (complaint.ComplaintCategory == 3)
                    model.ComplaintCategoryName = "Booking Concerns";
                if (complaint.ComplaintCategory == 4)
                    model.ComplaintCategoryName = "Others";

                if (complaint.ComplaintStatus == 1)
                    model.ComplaintStatusName = "Pending";
                if (complaint.ComplaintStatus == 2)
                    model.ComplaintStatusName = "Resolved";

                var complaintViewModel = new ComplaintsModel
                {
                    ComplaintID = ComplaintID,
                    AgentID = AgentID,
                    CustomerID = CustomerID,
                    DateOfEvent = DateOfEvent,
                    ComplaintCategoryName = model.ComplaintCategoryName,
                    ComplaintSubject = ComplaintSubject,
                    ComplaintDetails = ComplaintDetails,
                    ComplaintStatusName = model.ComplaintStatusName,
                    DateCreated = DateCreated
                };

                complaintList.Add(complaintViewModel);
            }

            ModelState.Clear();
            return View(complaintList);
        }

        public IActionResult AddComplaint(ComplaintsModel model, string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.AgentID = agentID;

            ModelState.Clear();
            return View(model);
        }
        public async Task<IActionResult> SaveComplaint(ComplaintsModel model)
        {
            await _dataAccess.AddComplaint(model);
            TempData["SuccessMessage"] = "Complaint Submitted Successfully!";
            return RedirectToAction("Complaints");
        }
    }
}
