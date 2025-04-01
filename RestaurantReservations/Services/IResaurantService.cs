using MongoDB.Bson;
using RestaurantReservations.Models;

namespace RestaurantReservations.Services;

public interface IResaurantService
{
    Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    Task<Restaurant?> GetRestaurantById(ObjectId id);

    Task AddRestaurantAsync(Restaurant restaurant);
    Task editRestaurantAsync(Restaurant restaurant);
    Task deleteRestaurant(Restaurant restaurant);
}
