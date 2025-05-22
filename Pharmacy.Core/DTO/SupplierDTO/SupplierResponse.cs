using Pharmacy.Core.Domain.Entities;
using Pharmacy.Core.DTO.SupplierDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.DTO.SupplierDTO
{
    public class SupplierResponse
    {
        public int SupplierId {set;get;}

        public string? Name { set; get; }

        public string? Email { set; get; }

        public string? Phone { set; get; }
         
        public ICollection<Purchase>? Purchases { set; get; }
    }
}


public static class SupplierExtension
{
    public static SupplierResponse ToSupplierResponse(this Supplier supplier)
    {
        return new SupplierResponse()
        {
            Email=supplier.Email,
            Name=supplier.Name,
            Phone=supplier.Phone,
            SupplierId=supplier.SupplierID,
            Purchases = supplier.Purchases
        };
    }
}