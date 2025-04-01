using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
//using MongoDB.Driver.Linq;
using RestaurantReservations.Models;

namespace RestaurantReservations.Services;

public class RestaurantService : IResaurantService
{
    private readonly RestaurantReservationDbContext _restaurantDbContext;
    public RestaurantService(RestaurantReservationDbContext context)
    {
        _restaurantDbContext = context;
    }

    public async Task AddRestaurantAsync(Restaurant restaurant)
    {
        _restaurantDbContext.Restaurants.Add(restaurant);
        _restaurantDbContext.ChangeTracker.DetectChanges();

        Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);

        await _restaurantDbContext.SaveChangesAsync();
    }

    public async Task deleteRestaurant(Restaurant restaurant)
    {
        var restaurantToDelete = await _restaurantDbContext.Restaurants
            .Where(c => c.Id == restaurant.Id).FirstOrDefaultAsync();

        if (restaurantToDelete != null)
        {
            _restaurantDbContext.Restaurants.Remove(restaurantToDelete);
            _restaurantDbContext.ChangeTracker.DetectChanges();

            Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);

            await _restaurantDbContext.SaveChangesAsync();
        }
    }

    public async Task editRestaurantAsync(Restaurant restaurant)
    {
        var restaurantToUpdate = await _restaurantDbContext.Restaurants
            .Where(c => c.Id == restaurant.Id).FirstOrDefaultAsync();

        if (restaurantToUpdate != null) 
        {
            restaurantToUpdate.name = restaurant.name;
            restaurantToUpdate.cuisine = restaurant.cuisine;
            restaurantToUpdate.borough = restaurant.borough;

            _restaurantDbContext.Restaurants.Update(restaurantToUpdate);
            _restaurantDbContext.ChangeTracker.DetectChanges();

            Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);

            await _restaurantDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        return await _restaurantDbContext.Restaurants
            .OrderByDescending(c => c.Id).Take(20).AsNoTracking()
            .ToListAsync();
    }

    public async Task<Restaurant?> GetRestaurantById(ObjectId id)
    {
        return await _restaurantDbContext.Restaurants
            .Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Restaurant>> searchRestaurantsAsync(string searchText) 
    {
        var client = new MongoClient("mongodb+srv://rbankspersonal:0WvhmSMxJngezf1e@crudpractice.rot5rrq.mongodb.net/?retryWrites=true&w=majority&appName=CRUDPractice\"");
        var database = client.GetDatabase("restaurants");
        var collection = database.GetCollection<Restaurant>("restaurants");

        var indexKeysDefinition = Builders<Restaurant>.IndexKeys.Text(r => r.name);//.Text(r => r.cuisine).Text(r => r.borough);
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<Restaurant>(indexKeysDefinition));

        var searchResults = await collection.Find(
            Builders<Restaurant>.Filter.Text(searchText))
            .ToListAsync();

        return searchResults;
    }
}
