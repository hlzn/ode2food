using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace odetoofd.data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Tacos Pepe", Location = "Centro", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 2, Name = "Pizza Pancho", Location = "Sur", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "Curry Lencha", Location = "Norte", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return (from r in restaurants
                    orderby r.Name
                    select r);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return (from r in restaurants
                    where string.IsNullOrEmpty(name) || r.Name.ToLower().Contains(name.ToLower())
                    select r);
        }

        public Restaurant GetById(int id)
        {
            return (from r in restaurants
                    where r.Id == id
                    select r).FirstOrDefault();
        }

        public Restaurant Update(Restaurant updatedResutaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedResutaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedResutaurant.Name;
                restaurant.Location = updatedResutaurant.Location;
                restaurant.Cuisine = updatedResutaurant.Cuisine;
            }
            return restaurant;

        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            var max = restaurants.Select(r => r.Id).Max();
            newRestaurant.Id = max+1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }

}