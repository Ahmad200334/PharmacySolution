using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Domain.Entities
{
    public class SaleItem
    {
        public int Id { get; set; }

        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        public Sale? Sale { get; set; }

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }
         
        // Denormalized
        public int ProductID { get; set; }

        public ICollection<InventoryItem>? InventoryItems { get; set; }
    }

}