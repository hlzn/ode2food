using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Core;

namespace odetofood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Tacos Pepe", Location = "Centro", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 1, Name = "Pizza Pancho", Location = "Sur", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 1, Name = "Curry Lencha", Location = "Norte", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return (from r in restaurants
                    orderby r.Name
                    select r);
        }
    }
}