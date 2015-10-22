using System.Data.Entity;
using Infrastructure.Persistance.Shop;

namespace Infrastructure.Persistance
{
    public class BakeryContext : DbContext
    {
        public BakeryContext()
            : base()
        {
            Database.SetInitializer<BakeryContext>(new DropCreateDatabaseIfModelChanges<BakeryContext>());
        }

        //Payment
        public DbSet<Payment.Payment> Payments { get; set; }
        
        //Shop
        public DbSet<Shop.Shop> Shops { get; set; }
    }
}
