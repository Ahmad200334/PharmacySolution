using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Domain.Entities
{
  public  class ProductCategory
    {
        [Key]
        public int CategoryID { set; get; }

        public string ? Name { set; get; }

        public ICollection<Product> ?Products { set; get; }
    }
}
