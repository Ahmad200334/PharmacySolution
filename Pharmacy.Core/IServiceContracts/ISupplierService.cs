using Pharmacy.Core.DTO.SupplierDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.IServiceContracts
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierResponse?>> GettAllSuppliers();

        Task<bool> DeleteSupplier(int id);

        Task<bool> UpdateSupplier(SupplierUpdateRequest supplierUpdateRequest);
        
        Task<SupplierResponse?> AddSupplier(SupplierAddRequest supplierUpdateRequest);

        Task<SupplierResponse?> GetsupplierById(int id);



    }
}
