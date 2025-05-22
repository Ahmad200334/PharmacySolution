using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Domain.Entities;
using Pharmacy.Core.Domain.IRepositoriesContracts;
using Pharmacy.Infrastructure.DbContext;

namespace Pharmacy.Infrastructure.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public SuppliersRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task AddSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                await _applicationDbContext.Suppliers.AddAsync(supplier);

                await _applicationDbContext.SaveChangesAsync();
                 
            }

        }

        public async Task<bool> DeleteSupplierById(int Id)
        {
            if (Id <= 0)
                return false;

            var supplier = await _applicationDbContext.Suppliers.FindAsync(Id);


            if (supplier == null) return false;


            _applicationDbContext.Suppliers.Remove(supplier);

            await _applicationDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _applicationDbContext.Suppliers
     .Include(s => s.Purchases)
     .ToListAsync();

        }

        public async Task<Supplier> GetSupplierById(int Id)
        {
            if (Id <= 0) return null;


            return
            await _applicationDbContext.Suppliers.FindAsync(Id);
        }

        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            if (supplier == null)
                return false;


            _applicationDbContext.Suppliers.Update(supplier);
            await _applicationDbContext.SaveChangesAsync();

            return true;
        }
    }
}
