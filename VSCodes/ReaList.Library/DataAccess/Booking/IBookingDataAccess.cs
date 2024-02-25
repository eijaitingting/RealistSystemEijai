using ReaList.Library.Model.Bookings;

namespace ReaList.Library.DataAccess.Booking
{
    public interface IBookingDataAccess
    {
        Task AddBooking(BookingModel model);
        Task UpdateBooking(BookingModel model);
        Task UpdateBookingStatus(BookingModel model);
        Task UpdateBookingPostStatus(BookingModel model);
        Task<bool> IsBookingExist(int CustomerID, int PropertyID);
        Task<bool> IsRatingExist(int BookingID, int AgentID, int CustomerID);
    }
}