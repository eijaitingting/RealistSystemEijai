using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ReaList.Library.DataAccess.Booking;
using ReaList.Library.DataAccess.Complaint;
using ReaList.Library.Helper;
using ReaList.Library.Model.Bookings;
using ReaList.Library.Model.Complaints;
using System.Reflection;
using System.Security.Claims;

namespace ReaList.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly ISqlDataAccess _db;
        private readonly IBookingDataAccess _dataAccess;

        public BookingController(ISqlDataAccess db, IBookingDataAccess dataAccess)
        {
            _db = db;
            _dataAccess = dataAccess;
        }

        public async Task<IActionResult> RecentBookings(BookingModel model)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.AgentID = agentID;

            var param = new { model.AgentID };
            var recentBookings = await _db.LoadData<BookingModel, dynamic>("sp_GetAllBookingsbyAgent", param);

            var recentBookingsList = new List<BookingModel>();

            foreach (var booking in recentBookings)
            {
                var BookingID = booking.BookingID;
                var PropertyName = booking.PropertyName;
                var City = booking.City;
                var Municipality = booking.Municipality;
                var VisitDate = booking.VisitDate;
                var VisitTime = booking.VisitTime;
                var CustomerName = booking.CustomerName;
                var PhoneNumber = booking.PhoneNumber;
                var Email = booking.Email;
                var BookingStatus = booking.BookingStatus;

                if (BookingStatus == 1)
                    model.BookingStatusName = "Pending";

                var bookingViewModel = new BookingModel
                {
                    BookingID = BookingID,
                    PropertyName = PropertyName,
                    City = City,
                    Municipality = Municipality,
                    VisitDate = VisitDate,
                    VisitTime = VisitTime,
                    CustomerName = CustomerName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    BookingStatus = BookingStatus,
                    BookingStatusName = model.BookingStatusName
                };

                recentBookingsList.Add(bookingViewModel);
            }

            ModelState.Clear();
            return View(recentBookingsList);
        }

        public async Task<IActionResult> ApprovedBookings(BookingModel model)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.AgentID = agentID;

            var param = new { model.AgentID };
            var recentBookings = await _db.LoadData<BookingModel, dynamic>("sp_GetAllBookingsbyAgent", param);

            var recentBookingsList = new List<BookingModel>();

            foreach (var booking in recentBookings)
            {
                var BookingID = booking.BookingID;
                var PropertyName = booking.PropertyName;
                var City = booking.City;
                var Municipality = booking.Municipality;
                var VisitDate = booking.VisitDate;
                var VisitTime = booking.VisitTime;
                var CustomerName = booking.CustomerName;
                var PhoneNumber = booking.PhoneNumber;
                var Email = booking.Email;
                var BookingStatus = booking.BookingStatus;
                var BookingPostStatus = booking.BookingPostStatus;

                if (BookingStatus == 2)
                    model.BookingStatusName = "Approved";
                if (BookingStatus == 2 && BookingPostStatus == 2)
                    model.BookingStatusName = "Completed";
                if (BookingStatus == 2 && BookingPostStatus == 3)
                    model.BookingStatusName = "No-Show";

                var bookingViewModel = new BookingModel
                {
                    BookingID = BookingID,
                    PropertyName = PropertyName,
                    City = City,
                    Municipality = Municipality,
                    VisitDate = VisitDate,
                    VisitTime = VisitTime,
                    CustomerName = CustomerName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    BookingStatus = BookingStatus,
                    BookingPostStatus = BookingPostStatus,
                    BookingStatusName = model.BookingStatusName
                };

                recentBookingsList.Add(bookingViewModel);
            }

            ModelState.Clear();
            return View(recentBookingsList);
        }

        public async Task<IActionResult> RescheduledBookings(BookingModel model)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.AgentID = agentID;

            var param = new { model.AgentID };
            var recentBookings = await _db.LoadData<BookingModel, dynamic>("sp_GetAllBookingsbyAgent", param);

            var recentBookingsList = new List<BookingModel>();

            foreach (var booking in recentBookings)
            {
                var BookingID = booking.BookingID;
                var PropertyName = booking.PropertyName;
                var City = booking.City;
                var Municipality = booking.Municipality;
                var VisitDate = booking.VisitDate;
                var VisitTime = booking.VisitTime;
                var CustomerName = booking.CustomerName;
                var PhoneNumber = booking.PhoneNumber;
                var Email = booking.Email;
                var BookingStatus = booking.BookingStatus;

                if (BookingStatus == 3)
                    model.BookingStatusName = "Reschedule";

                var bookingViewModel = new BookingModel
                {
                    BookingID = BookingID,
                    PropertyName = PropertyName,
                    City = City,
                    Municipality = Municipality,
                    VisitDate = VisitDate,
                    VisitTime = VisitTime,
                    CustomerName = CustomerName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    BookingStatus = BookingStatus,
                    BookingStatusName = model.BookingStatusName
                };

                recentBookingsList.Add(bookingViewModel);
            }

            ModelState.Clear();
            return View(recentBookingsList);
        }

        public async Task<IActionResult> CancelledBookings(BookingModel model)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.AgentID = agentID;

            var param = new { model.AgentID };
            var recentBookings = await _db.LoadData<BookingModel, dynamic>("sp_GetAllBookingsbyAgent", param);

            var recentBookingsList = new List<BookingModel>();

            foreach (var booking in recentBookings)
            {
                var BookingID = booking.BookingID;
                var PropertyName = booking.PropertyName;
                var City = booking.City;
                var Municipality = booking.Municipality;
                var VisitDate = booking.VisitDate;
                var VisitTime = booking.VisitTime;
                var CustomerName = booking.CustomerName;
                var PhoneNumber = booking.PhoneNumber;
                var Email = booking.Email;
                var BookingStatus = booking.BookingStatus;

                if (BookingStatus == 4)
                    model.BookingStatusName = "Cancelled";

                var bookingViewModel = new BookingModel
                {
                    BookingID = BookingID,
                    PropertyName = PropertyName,
                    City = City,
                    Municipality = Municipality,
                    VisitDate = VisitDate,
                    VisitTime = VisitTime,
                    CustomerName = CustomerName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    BookingStatus = BookingStatus,
                    BookingStatusName = model.BookingStatusName
                };

                recentBookingsList.Add(bookingViewModel);
            }

            ModelState.Clear();
            return View(recentBookingsList);
        }

        public async Task<IActionResult> Bookings(BookingModel model)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            var customerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.CustomerID = customerID;

            var param = new { model.CustomerID };
            var bookingsInfo = await _db.LoadData<BookingModel, dynamic>("sp_GetAllBookingsbyCustomer", param);

            var bookingList = new List<BookingModel>();

            foreach (var booking in bookingsInfo)
            {
                var BookingID = booking.BookingID;
                var AgentID = booking.AgentID;
                var PropertyName = booking.PropertyName;
                var Location = booking.Location;
                var PropertyCategoryName = booking.PropertyCategoryName;
                var PropertyTypeName = booking.PropertyTypeName;
                var VisitDate = booking.VisitDate;
                var VisitTime = booking.VisitTime;
                var BookingStatus = booking.BookingStatus;
                var BookingPostStatus = booking.BookingPostStatus;
                var MainPhoto = booking.MainPhoto;

                if (BookingStatus == 1)
                    model.BookingStatusName = "Approval Pending";
                if (BookingStatus == 2)
                    model.BookingStatusName = "Approved";
                if (BookingStatus == 3)
                    model.BookingStatusName = "Reschedule";
                if (BookingStatus == 4)
                    model.BookingStatusName = "Cancelled";

                if (BookingPostStatus == 2)
                    model.BookingPostStatusName = "Completed";
                if (BookingPostStatus == 3)
                    model.BookingPostStatusName = "No Show";

                if (await _dataAccess.IsRatingExist(BookingID, AgentID, model.CustomerID))
                    model.isRatingExists = 1;
                    
                var bookingViewModel = new BookingModel
                {
                    BookingID = BookingID,
                    AgentID = AgentID,
                    PropertyName = PropertyName,
                    Location = Location,
                    PropertyCategoryName = PropertyCategoryName,
                    PropertyTypeName = PropertyTypeName,
                    VisitDate = VisitDate,
                    VisitTime = VisitTime,
                    BookingStatus = BookingStatus,
                    BookingPostStatus = BookingPostStatus,
                    BookingStatusName = model.BookingStatusName,
                    BookingPostStatusName = model.BookingPostStatusName,
                    MainPhoto = MainPhoto,
                    isRatingExists = model.isRatingExists
                };

                bookingList.Add(bookingViewModel);
            }

            ModelState.Clear();
            return View(bookingList);
        }

        public async Task<IActionResult> Book(BookingModel model, int propertyId)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            var customerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.CustomerID = customerID;

            model.PropertyID = propertyId;
            var param = new { model.PropertyID };
            var propertyInfo = await _db.LoginUser<BookingModel, dynamic>("sp_GetSpecificPropertyDetails", param);

            if (propertyInfo != null)
            {
                model.PropertyID = propertyInfo.PropertyID;
                model.AgentID = propertyInfo.AgentID;
            }

            ModelState.Clear();
            return View(model);
        }

        public async Task<IActionResult> AddBooking(BookingModel model)
        {
            if (await _dataAccess.IsBookingExist(model.CustomerID, model.PropertyID))
            {
                var errorMessage = "You have an existing booking with this property!";
                ModelState.AddModelError("Booking", errorMessage);
                return RedirectToAction("PropertyDetails", "Property", new { message = errorMessage, id = model.PropertyID });
            }

            await _dataAccess.AddBooking(model);
            TempData["SuccessMessage"] = "Booking Successful!";
            return RedirectToAction("PropertyDetails", "Property", new { id = model.PropertyID });
        }

        public async Task<IActionResult> EditBooking(BookingModel model, int id)
        {
            model.BookingID = id;

            var param = new { model.BookingID };
            var bookingInfo = await _db.LoginUser<BookingModel, dynamic>("sp_GetSpecificBooking", param);

            if (bookingInfo != null)
            {
                model.VisitDate = bookingInfo.VisitDate;
                model.VisitTime = bookingInfo.VisitTime;
            }

            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(BookingModel model)
        {
            model.BookingStatus = 1;

            await _dataAccess.UpdateBooking(model);
            TempData["SuccessMessage"] = "Booking updated successfully!";
            return RedirectToAction("Bookings");
        }

        public async Task<IActionResult> CancelBooking(BookingModel model, int id)
        {
            model.BookingID = id;
            model.BookingStatus = 4;

            await _dataAccess.UpdateBookingStatus(model);
            TempData["SuccessMessage"] = "Booking cancelled successfully!";
            return RedirectToAction("Bookings");
        }

        public async Task<IActionResult> Approve(BookingModel model, int id)
        {
            model.BookingID = id;
            model.BookingStatus = 2;

            await _dataAccess.UpdateBookingStatus(model);
            TempData["SuccessMessage"] = "Booking has been approved!";
            return RedirectToAction("RecentBookings");
        }

        public async Task<IActionResult> Reschedule(BookingModel model, int id)
        {
            model.BookingID = id;
            model.BookingStatus = 3;

            await _dataAccess.UpdateBookingStatus(model);
            TempData["SuccessMessage"] = "Booking set to reschedule";
            return RedirectToAction("RescheduledBookings");
        }

        public async Task<IActionResult> Cancel(BookingModel model, int id)
        {
            model.BookingID = id;
            model.BookingStatus = 4;

            await _dataAccess.UpdateBookingStatus(model);
            TempData["SuccessMessage"] = "Booking cancelled successfully!";
            return RedirectToAction("CancelledBookings");
        }

        public async Task<IActionResult> Complete(BookingModel model, int id)
        {
            model.BookingID = id;
            model.BookingPostStatus = 2;

            await _dataAccess.UpdateBookingPostStatus(model);
            TempData["SuccessMessage"] = "Booking marked as Complete!";
            return RedirectToAction("ApprovedBookings");
        }

        public async Task<IActionResult> NoShow(BookingModel model, int id)
        {
            model.BookingID = id;
            model.BookingPostStatus = 3;

            await _dataAccess.UpdateBookingPostStatus(model);
            TempData["SuccessMessage"] = "Booking marked as No-Show!";
            return RedirectToAction("ApprovedBookings");
        }
    }
}
