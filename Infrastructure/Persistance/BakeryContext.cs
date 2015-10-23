using System.Data.Entity;

namespace Infrastructure.Persistance
{
    public class BakeryContext : DbContext
    {
        public BakeryContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BakeryContext>());
        }

        //Payment
        public DbSet<Payment.Payment> Payments { get; set; }
        
        //Shop
        public DbSet<Shop.Shop> Shops { get; set; }

        //Route
        public DbSet<Route.Route> Routes { get; set; }

        //Assortment
        public DbSet<Product.Product> Products { get; set; }

        //RouteProductMap
        public DbSet<RouteProductMap.RouteProductMap> RouteProductMaps { get; set; }

        //ShopProductMap
        public DbSet<ShopProductMap.ShopProductMap> ShopProductMaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RouteShop.RouteShop>().HasKey(e => new {e.RouteName, e.ShopCode});
        }
    }
}
