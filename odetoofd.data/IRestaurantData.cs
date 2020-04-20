using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Core;

namespace odetoofd.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);

        Restaurant Update(Restaurant updatedRestaurant);

        int Commit();

        Restaurant Add(Restaurant newRestaurant);

        Restaurant Delete(int id);

        int GetCountOfRestaurants();
    }

    

    
}