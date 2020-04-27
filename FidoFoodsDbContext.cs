using System.Data.Entity;
using TestData.Web.Models;

namespace TestData.Web.Services
{
    //class derives from.. DbContext, System.Data.Entity
    public class FidoFoodsDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}