using MongoDB.Bson;
using RestaurantReservations.Models;

namespace RestaurantReservations.Services;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetAllReservations();
    Task<Reservation?> GetReservationById(ObjectId id);
    Task AddReservation(Reservation newReservation);
    Task EditReservation(Reservation updatedReservation);
    Task DeleteReservation(Reservation reservationToDelete);
}
