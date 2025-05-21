using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Domain.Entities
{
   public class Supplier
    {
          
        [Key]
        public int SupplierID { set; get; }
     
        public string? Name { set; get; }
        
        public string? Phone{ set; get; }
        
        [EmailAddress]
        public string? Email { set; get; }
      
        public ICollection<Purchase> ?Purchases { set; get; }
   }
}
