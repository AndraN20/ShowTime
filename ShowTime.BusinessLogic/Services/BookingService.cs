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
        private readonly ITicketRepository _ticketRepo;

        public BookingService(IBookingRepository bookingRepo, IFestivalRepository festivalRepo, ITicketRepository ticketRepo)
        {
            _bookingRepo = bookingRepo;
            _festivalRepo = festivalRepo;
            _ticketRepo = ticketRepo;
        }

        public async Task<BookingGetDto> CreateBookingAsync(BookingCreateDto dto)
        {
            var ticket = await _ticketRepo.GetByIdAsync(dto.TicketId);
            if (ticket == null)
                throw new Exception("Ticket not found");

            var existingBooking = await _bookingRepo.GetBookingAsync(dto.UserId, ticket.FestivalId, ticket.Id);

            var totalBooked = await _bookingRepo.GetTotalBookedQuantityForTicketAsync(ticket.Id);

            int newUserTotal = dto.Quantity;
            if (existingBooking != null)
                newUserTotal += existingBooking.Quantity;

            int totalIfAccepted = totalBooked - (existingBooking?.Quantity ?? 0) + newUserTotal;

            if (totalIfAccepted > ticket.MaxQuantity)
                throw new Exception("Not enough tickets available for this ticket type.");

            Booking booking;
            if (existingBooking != null)
            {
                existingBooking.Quantity = newUserTotal;
                existingBooking.Price = ticket.Price * existingBooking.Quantity;
                booking = await _bookingRepo.UpdateAsync(existingBooking);
            }
            else
            {
                booking = new Booking
                {
                    FestivalId = ticket.FestivalId,
                    UserId = dto.UserId,
                    TicketId = ticket.Id,
                    Quantity = dto.Quantity,
                    Price = ticket.Price * dto.Quantity,
                };
                booking = await _bookingRepo.CreateAsync(booking);
            }

            var result = await _bookingRepo.GetBookingAsync(booking.UserId, booking.FestivalId, booking.TicketId);

            if (result == null)
                throw new Exception("Could not retrieve created booking");

            return new BookingGetDto
            {
                FestivalId = result.FestivalId,
                FestivalName = result.Festival?.Name ?? "",
                UserId = result.UserId,
                UserEmail = result.User?.Email ?? "",
                TicketId = result.TicketId,
                TicketName = result.Ticket?.Name ?? "",
                TicketPrice = result.Ticket?.Price ?? 0,
                Quantity = result.Quantity,
                Price = result.Price
            };
        }



        public async Task DeleteBookingAsync(int userId, int festivalId, int ticketId)
        {
            await _bookingRepo.DeleteAsync(userId, festivalId, ticketId);
        }

        public async Task<IList<BookingGetDto>> GetBookingsForUserAsync(int userId)
        {
            var bookings = await _bookingRepo.GetBookingsForUserAsync(userId);

            return bookings.Select(b => new BookingGetDto
            {
                FestivalId = b.FestivalId,
                FestivalName = b.Festival?.Name ?? "",
                UserId = b.UserId,
                UserEmail = b.User?.Email ?? "",
                TicketId = b.TicketId,
                TicketName = b.Ticket?.Name ?? "",
                TicketPrice = b.Ticket?.Price ?? 0,
                Quantity = b.Quantity,
                Price = b.Quantity * (b.Ticket?.Price ?? 0)
            }).ToList();
        }

        public async Task<BookingGetDto> UpdateBookingAsync(int userId, int festivalId, int ticketId, int newQuantity)
        {
            var booking = await _bookingRepo.GetBookingAsync(userId, festivalId, ticketId);
            if (booking == null)
                throw new Exception("Booking not found.");

            var ticket = await _ticketRepo.GetByIdAsync(ticketId);
            if (ticket == null)
                throw new Exception("Ticket not found.");

            if (newQuantity > ticket.MaxQuantity)
                throw new Exception("Quantity exceeds maximum allowed.");

            booking.Quantity = newQuantity;
            booking.Price = ticket.Price * newQuantity;

            booking = await _bookingRepo.UpdateAsync(booking);

            var updatedBooking = await _bookingRepo.GetBookingAsync(userId, festivalId, ticketId);
            if (updatedBooking == null)
                throw new Exception("Could not retrieve updated booking");

            return new BookingGetDto
            {
                FestivalId = updatedBooking.FestivalId,
                FestivalName = updatedBooking.Festival?.Name ?? "",
                UserId = updatedBooking.UserId,
                UserEmail = updatedBooking.User?.Email ?? "",
                TicketId = updatedBooking.TicketId,
                TicketName = updatedBooking.Ticket?.Name ?? "",
                TicketPrice = updatedBooking.Ticket?.Price ?? 0,
                Quantity = updatedBooking.Quantity,
                Price = updatedBooking.Price
            };
        }
        public async Task<IList<BookingGetDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepo.GetAllBookingsAsync();
            return bookings.Select(b => new BookingGetDto
            {
                FestivalId = b.FestivalId,
                FestivalName = b.Festival?.Name ?? "",
                UserId = b.UserId,
                UserEmail = b.User?.Email ?? "",
                TicketId = b.TicketId,
                TicketName = b.Ticket?.Name ?? "",
                TicketPrice = b.Ticket?.Price ?? 0,
                Quantity = b.Quantity,
                Price = b.Price
            }).ToList();
        }



    }



}
