using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Domain.Entities;
using Pharmacy.Core.Domain.Entities.IdentityEntities;

namespace Pharmacy.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<Product> Products { set; get; }

        public DbSet<StockMovement> StockMovements { set; get; }

        public DbSet<MedicineCategory> MedicineCategories { set; get; }
        public DbSet<MedicineType> MedicineTypes { set; get; }
        public DbSet<Medicine> Medicines { set; get; }
        public DbSet<Notification> Notifications{ set; get; }
        public DbSet<Supplier> Suppliers{ set; get; }
        public DbSet<Purchase> Purchases { set; get; }
        public DbSet<PurchaseItem> PurchaseItems { set; get; }
        public DbSet<Batch> Batches { set; get; }
        public DbSet<InventoryItem> InventoryItems { set; get; }
        public DbSet<Employee> Employees { set; get; }
        public DbSet<Sale> Sales { set; get; }
        public DbSet<SaleItem> SaleItems { set; get; }

        public DbSet<DamagedProduct> DamagedProducts { set; get; }



        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




        }

    }
}
