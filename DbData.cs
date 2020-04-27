using System.Linq;
using TestData.Web.Models;

namespace TestData.Web.Services
{
    public class DbData : FidoFoodsDbContext
    {
        public DbData()
        {
            var db = new FidoFoodsDbContext().Restaurants;
        }

        public void Add(Restaurant restaurant)
        {
            Restaurants.Add(restaurant);
        }

        //return restaurant w/ Id
        public Restaurant Get(int id)
        {
            return Restaurants.FirstOrDefault(r => r.Id == id);
        }
        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);

            existing.Name = restaurant.Name;
            existing.Description = restaurant.Description;

        }

        public void Delete(int Id)
        {
            var restaurant = Get(Id);

            if (restaurant != null || restaurant == null)
            {
                Restaurants.Remove(restaurant);
            }
        }

    }
}