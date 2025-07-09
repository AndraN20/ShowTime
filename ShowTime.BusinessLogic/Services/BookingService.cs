using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Booking;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IFestivalRepository _festivalRepo;

        public BookingService(IBookingRepository bookingRepo, IFestivalRepository festivalRepo)
        {
            _bookingRepo = bookingRepo;
            _festivalRepo = festivalRepo;
        }

        public async Task<BookingGetDto> CreateBookingAsync(BookingCreateDto dto)
        {
            try
            {
                int unitPrice = dto.Type.ToLower() == "vip" ? 200 : 100;
                int totalPrice = unitPrice * dto.Quantity;

                var booking = new Booking
                {
                    FestivalId = dto.FestivalId,
                    UserId = dto.UserId,
                    Type = dto.Type,
                    Quantity = dto.Quantity,
                    Price = totalPrice,
                };

                var created = await _bookingRepo.CreateAsync(booking);

                return new BookingGetDto
                {
                    FestivalId = created.FestivalId,
                    UserId = created.UserId,
                    Type = created.Type,
                    Quantity = created.Quantity,
                    Price = created.Price
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating booking.", ex);
            }
        }

        public async Task<IList<BookingGetDto>> GetBookingsForUserAsync(int userId)
        {
            try
            {
                var bookings = await _bookingRepo.GetBookingsForUserAsync(userId);
                return bookings.Select(b => new BookingGetDto
                {
                    FestivalId = b.FestivalId,
                    UserId = b.UserId,
                    Type = b.Type,
                    Quantity = b.Quantity,
                    Price = b.Price,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting bookings for user.", ex);
            }
        }

        public async Task DeleteBookingAsync(int festivalId, int userId)
        {
            try
            {
                await _bookingRepo.DeleteAsync(festivalId, userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting booking for festivalId {festivalId} and userId {userId}.", ex);
            }
        }

        public async Task<BookingGetDto> UpdateBookingQuantityAsync(int festivalId, int userId, int newQuantity)
        {
            try
            {
                var booking = await _bookingRepo.GetByIdAsync(festivalId, userId);
                if (booking == null)
                {
                    throw new KeyNotFoundException($"Booking with festivalId {festivalId} and userId {userId} not found.");
                }

                int unitPrice = booking.Type.ToLower() == "vip" ? 200 : 100;
                booking.Quantity = newQuantity;
                booking.Price = unitPrice * newQuantity;

                var updated = await _bookingRepo.UpdateAsync(booking);

                return new BookingGetDto
                {
                    FestivalId = updated.FestivalId,
                    UserId = updated.UserId,
                    Type = updated.Type,
                    Quantity = updated.Quantity,
                    Price = updated.Price
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating booking quantity for festivalId {festivalId} and userId {userId}.", ex);
            }
        }
    }



}
