using ShowTime.BusinessLogic.DTOs.Booking;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IBookingService
    {
        Task<BookingGetDto> CreateBookingAsync(BookingCreateDto dto);
        Task<IList<BookingGetDto>> GetBookingsForUserAsync(int userId);
        Task DeleteBookingAsync( int userId, int festivalId, int ticketId);
        Task<BookingGetDto> UpdateBookingAsync( int userId, int festivalId, int ticketId, int quantity);
        Task<IList<BookingGetDto>> GetAllBookingsAsync();

    }
}
