using ShowTime.BusinessLogic.DTOs.Booking;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IBookingService
    {
        Task<BookingGetDto> CreateBookingAsync(BookingCreateDto dto);
        Task<IList<BookingGetDto>> GetBookingsForUserAsync(int userId);
        Task DeleteBookingAsync(int festivalId, int userId);
        Task<BookingGetDto> UpdateBookingQuantityAsync(int festivalId, int userId, int newQuantity);
    }
}
