
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using RestaurantReservations.Models;
using RestaurantReservations.Services;

MongoDbSettings settings = new MongoDbSettings() { 
    AtlasUri = "mongodb+srv://rbankspersonal:0WvhmSMxJngezf1e@crudpractice.rot5rrq.mongodb.net/?retryWrites=true&w=majority&appName=CRUDPractice",
    DatabaseName = "CRUDPractice"
};

var dbContextOptions = new DbContextOptionsBuilder<RestaurantReservationDbContext>().UseMongoDB(settings.AtlasUri, 
    settings.DatabaseName);

using (var restaurantReservationDbContext = new RestaurantReservationDbContext(dbContextOptions.Options))
{
    var restaurantService = new RestaurantService(restaurantReservationDbContext);

    #region Add Restaurant
    //await restaurantService.AddRestaurant(
    //    new Restaurant
    //    {
    //        name = "Milas bangers and mash",
    //        cuisine = "English",
    //        borough = "Milford on sea"
    //    }
    //);
    #endregion Add Restaurant

    #region Delete Restaurant
    //var restaurantId = "67eaa519f86c89f16fce7deb";

    //var restaurantToDelete = await restaurantService
    //    .GetRestaurantById(new ObjectId(restaurantId));

    //if (restaurantToDelete != null)
    //{
    //    //how do i know its deleted successfully?
    //    //look into this!
    //    await restaurantService.deleteRestaurant(restaurantToDelete);
    //    Console.WriteLine($"Restaurant called {restaurantToDelete.name} deleted");

    //    return;
    //}

    //Console.WriteLine($"Restaurant with id: {restaurantId} does not exist");

    #endregion Delete Restaurant

    #region Update Restaurant
    //var restaurantId = "67eaa56a5d342fbe4dfb8458";

    //var restaurantToUpdate = await restaurantService
    //    .GetRestaurantById(new ObjectId(restaurantId));

    //if (restaurantToUpdate != null) 
    //{
    //    restaurantToUpdate.borough = "Southampton";

    //    await restaurantService.editRestaurant(restaurantToUpdate);
    //    Console.WriteLine($"Restaurant called {restaurantToUpdate.name} updated");
    //}

    //Console.WriteLine($"Restaurant with id: {restaurantId} does not exist");

    #endregion Update Restaurant

    #region Get all restaurants
    //var restuarants = await restaurantService.GetAllRestaurants();

    //foreach (var restaurant in restuarants)
    //{
    //    Console.WriteLine($"{restaurant.name}, {restaurant.cuisine}, {restaurant.borough}");
    //}

    #endregion Get all restaurants

    #region Search Restaurant

    //var results = await restaurantService.searchRestaurantsAsync("Southampton11111");

    //foreach (var restaurant in results)
    //{
    //    Console.WriteLine($"{restaurant.name}, {restaurant.cuisine}, {restaurant.borough}");
    //}

    #endregion Search Restaurant

    var reservationService = new ReservationService(restaurantReservationDbContext);

    #region Add Reservation

    //var newReservation = new Reservation
    //{
    //    RestaurantId = new ObjectId("67eaa483de246a8cb0e38205"),
    //    RestaurantName = "Richs Eats",
    //    date = new DateTime(2025, 08, 31, 15, 00, 00)
    //};

    ////how do i know its added successfully?
    ////look into this!
    //await reservationService.AddReservation(newReservation);
    //Console.WriteLine($"Reservation added");

    #endregion Add Reservation

    #region Delete Reservation

    //var reservationId = "67eaab28877c365bd5a910a3";
    //var reservationToDelete = await reservationService.GetReservationById(new ObjectId(reservationId));

    //if (reservationToDelete != null)
    //{
    //    await reservationService.DeleteReservation(reservationToDelete);
    //    Console.WriteLine($"Reservation deleted");
    //    return;
    //}

    //Console.WriteLine($"Reservation with id: {reservationId} does not exist");

    #endregion Delete Reservation

    #region Update Reservation

    //var reservationId = "67eaab3e617a0508de8f7ea1";
    //var reservationToUpdate = await reservationService.GetReservationById(new ObjectId(reservationId));

    //if (reservationToUpdate != null)
    //{
    //    reservationToUpdate.date = new DateTime(2025, 09, 01, 13, 00, 00);

    //    //how do i know this was successfull?
    //    //look into this!
    //    await reservationService.EditReservation(reservationToUpdate);

    //    Console.WriteLine($"Reservation with id: {reservationId} updated");
    //    return;
    //}

    //Console.WriteLine($"Reservation with id: {reservationId} does not exist");

    #endregion Update Reservation
}



