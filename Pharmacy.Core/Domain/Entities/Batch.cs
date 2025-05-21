using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Domain.Entities
{
    public class Batch
    { 

        [Key]
        public int BatchID { set; get; }

        public int ?Quantity { set; get; }

        [Precision(18, 2)]
        public decimal? CurrentPrice { set;get; }


        public string ?Barcode { get; set; }

        public string? BatchNumber { get; set; }

        public DateTime ExpirationDate { set; get; }

        // Denormalized field
        public int Product { get; set; }

        [ForeignKey("PurchaseItem")]
        public int PurchaseItemId { get; set; }
 
        public PurchaseItem? PurchaseItem { get; set; }

        public DateTime? LastUpdate { set; get; }
         
        public DamagedProduct ? DamagedProduct { set; get; }

        public ICollection<InventoryItem>? InventoryItems { get; set; }
         
        // قائمة الإشعارات المرتبطة بهذه الدفعة
        public ICollection<Notification>? Notifications { get; set; }
    }

}
