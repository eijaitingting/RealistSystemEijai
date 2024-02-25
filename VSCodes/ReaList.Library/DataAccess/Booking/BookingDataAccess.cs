using ReaList.Library.DataAccess.Complaint;
using ReaList.Library.Helper;
using ReaList.Library.Model.Bookings;
using ReaList.Library.Model.Complaints;
using ReaList.Library.Model.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Booking
{
    public class BookingDataAccess : IBookingDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public BookingDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> IsBookingExist(int CustomerID, int PropertyID)
        {
            var data = await _dataAccess.LoadSingle<PropertyModel, dynamic>("sp_GetBookingbyCustomerIDandPropertyID", new { CustomerID, PropertyID });
            return data != null;
        }

        public async Task<bool> IsRatingExist(int BookingID, int AgentID, int CustomerID)
        {
            var data = await _dataAccess.LoadSingle<PropertyModel, dynamic>("sp_GetAgentRating", new { BookingID, AgentID, CustomerID });
            return data != null;
        }

        public async Task AddBooking(BookingModel model)
        {
            var parameters = new
            {
                model.BookingID,
                model.AgentID,
                model.CustomerID,
                model.PropertyID,
                model.VisitDate,
                model.VisitTime,
                model.BookingStatus,
                model.BookingPostStatus,
                model.DateCreated
            };
            await _dataAccess.ExecuteQuery("sp_AddBooking", parameters);
        }

        public async Task UpdateBooking(BookingModel model)
        {
            var parameters = new
            {
                model.BookingID,
                model.VisitDate,
                model.VisitTime,
                model.BookingStatus,
                model.DateUpdated
            };
            await _dataAccess.ExecuteQuery("sp_UpdateBooking", parameters);
        }

        public async Task UpdateBookingStatus(BookingModel model)
        {
            var parameters = new
            {
                model.BookingID,
                model.BookingStatus
            };
            await _dataAccess.ExecuteQuery("sp_UpdateBookingStatus", parameters);
        }

        public async Task UpdateBookingPostStatus(BookingModel model)
        {
            var parameters = new
            {
                model.BookingID,
                model.BookingPostStatus
            };
            await _dataAccess.ExecuteQuery("sp_UpdateBookingPostStatus", parameters);
        }
    }
}
