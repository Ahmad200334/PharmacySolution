using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Domain.Entities
{
    public class Product
    {  
        [Key]
        public int ProductID { set; get; }

        public string? Name { set; get; }
         
         
        public string? Description { set; get; }

         
        [ForeignKey("Category")]
        public int CategoryProductID { set; get; }
        public ProductCategory? ProductCategory { set; get; }

    
        public ICollection<PurchaseItem>? PurchaseItems { set; get; }
        
        public ICollection<Notification>? Notifications{ set; get; }

        public ICollection<StockMovement>? StockMovements { set; get; }

        public ICollection<DamagedProduct>? DamagedProducts { set; get; }
         
        public int MinimumStockLevel { get; set; } // الحد الأدنى

        public Medicine ? Medicine { set;get; }
    }
}
