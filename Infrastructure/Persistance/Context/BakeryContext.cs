using System.Data.Entity;
using Infrastructure.Persistance.Context.PriceList.Route;
using Infrastructure.Persistance.Context.PriceList.Shop;
using Infrastructure.Persistance.Context.ProductMap.Route;
using Infrastructure.Persistance.Context.ProductMap.Shop;

namespace Infrastructure.Persistance.Context
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
        public DbSet<RouteProductMap> RouteProductMaps { get; set; }

        //ShopProductMap
        public DbSet<ShopProductMap> ShopProductMaps { get; set; }

        //RoutePriceList
        public DbSet<RoutePriceList> RoutePriceLists { get; set; }

        //ShopPriceList
        public DbSet<ShopPriceList> ShopPriceLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RouteShop.RouteShop>().HasKey(e => new {e.RouteName, e.ShopCode});
        }
    }
}
