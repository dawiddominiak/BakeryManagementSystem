using System.Data.Entity;
using Infrastructure.Persistance.Context.PriceList.Route;
using Infrastructure.Persistance.Context.PriceList.Shop;
using Infrastructure.Persistance.Context.ProductMap.Route;
using Infrastructure.Persistance.Context.ProductMap.Shop;
using Infrastructure.Persistance.Context.Shop;

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
        
        //Owner
        public DbSet<Owner> Owners { get; set; }

        //OwnerAddresses
        public DbSet<OwnerAddress> OwnerAddresses { get; set; }

        //OwnerPhones
        public DbSet<OwnerPhone> OwnerPhones { get; set; }

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

            modelBuilder.Entity<OwnerAddress>()
                .HasKey(e => e.OwnerId)
            ;

            modelBuilder.Entity<Owner>()
                .HasOptional(o => o.OwnerAddress)
                .WithRequired(ad => ad.Owner)
            ;

            modelBuilder.Entity<OwnerPhone>()
                .HasRequired<Owner>(op => op.Owner)
                .WithMany(o => o.Phones)
                .HasForeignKey(o => o.OwnerId)
            ;

        }
    }
}
