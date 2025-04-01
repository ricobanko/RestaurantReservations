using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
//using MongoDB.Driver.Linq;
using RestaurantReservations.Models;

namespace RestaurantReservations.Services;

public class ReservationService : IReservationService
{
    RestaurantReservationDbContext _restaurantDbContext;

    public ReservationService(RestaurantReservationDbContext restaurantReservationDbContext)
    {
        _restaurantDbContext = restaurantReservationDbContext;
    }

    public async Task AddReservation(Reservation newReservation)
    {
        var bookedRestaurant = await _restaurantDbContext.Restaurants
            .Where(r => r.Id == newReservation.RestaurantId).FirstOrDefaultAsync();

        if (bookedRestaurant == null) 
        {
            throw new ArgumentException("The restaurant to be reserved cannot be found.");
        }

        newReservation.RestaurantName = bookedRestaurant.name;

        _restaurantDbContext.Reservations.Add(newReservation);
        _restaurantDbContext.ChangeTracker.DetectChanges();

        Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);
        await _restaurantDbContext.SaveChangesAsync();
    }

    public async Task DeleteReservation(Reservation reservation)
    {
        var reservationToDelete = await _restaurantDbContext.Reservations
            .Where(r => r.Id == reservation.Id).FirstOrDefaultAsync();

        if (reservationToDelete == null)
        {
            throw new ArgumentException("The reservation to delete cannot be found.");
        }

        _restaurantDbContext.Reservations.Remove(reservationToDelete);

        _restaurantDbContext.ChangeTracker.DetectChanges();
        Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);

        await _restaurantDbContext.SaveChangesAsync();
    }

    public async Task EditReservation(Reservation updatedReservation)
    {
        var reservationToUpdate = await _restaurantDbContext.Reservations
            .Where(r => r.Id == updatedReservation.Id).FirstOrDefaultAsync();

        if (reservationToUpdate == null) {
            throw new ArgumentException("Reservation to update cannot be found.");
        }

        reservationToUpdate.date = updatedReservation.date;
        _restaurantDbContext.Reservations.Update(reservationToUpdate);

        _restaurantDbContext.ChangeTracker.DetectChanges();
        Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);

        await _restaurantDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        return await _restaurantDbContext.Reservations
            .OrderBy(r => r.date).Take(20).AsNoTracking()
            .ToListAsync();
    }

    public async Task<Reservation?> GetReservationById(ObjectId id)
    {
        return await _restaurantDbContext.Reservations.AsNoTracking()
            .Where(r => r.Id == id).FirstOrDefaultAsync();
    }
}
