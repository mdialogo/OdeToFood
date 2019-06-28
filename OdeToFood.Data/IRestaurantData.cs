using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "MaryLand", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Indian },
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)
                   orderby r.Name
                   select r;
        }
    }
}
