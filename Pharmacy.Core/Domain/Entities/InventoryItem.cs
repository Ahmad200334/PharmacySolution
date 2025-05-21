using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Domain.Entities
{
    public class InventoryItem
    {
        public int InventoryItemID { get; set; }

        [ForeignKey("Batch")]
        public int BatchId { get; set; }
        public Batch ?Batch { get; set; }

        [ForeignKey("SaleItem")]
        public int SaleItemId { get; set; }

        public SaleItem? SaleItem { get; set; }

        public int QuantitySoldFromBatch { get; set; }
    }

}
