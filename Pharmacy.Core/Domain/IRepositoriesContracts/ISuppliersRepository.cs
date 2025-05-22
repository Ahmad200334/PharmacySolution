using Pharmacy.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Domain.IRepositoriesContracts
{
    public interface ISuppliersRepository
    {
        Task AddSupplier(Supplier supplier);

        Task<IEnumerable<Supplier>> GetAllSuppliers();

        Task<bool>  UpdateSupplier(Supplier supplier);

        Task<Supplier> GetSupplierById(int Id);

        Task<bool> DeleteSupplierById(int Id);

    }
}
