using Pharmacy.Core.Domain.IRepositoriesContracts;
using Pharmacy.Core.DTO.SupplierDTO;
using Pharmacy.Core.IServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SupplierService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public async Task<SupplierResponse?> AddSupplier(SupplierAddRequest supplierUpdateRequest)
        { 
            if(supplierUpdateRequest == null)
            {
                return null;
            }
            var supplier = supplierUpdateRequest.ToSupplier();
            await _suppliersRepository.AddSupplier(supplier);


            return supplier.ToSupplierResponse();
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            return
            await _suppliersRepository.DeleteSupplierById(id);
        }

        public async Task<SupplierResponse?> GetsupplierById(int id)
        {

            var supplier = await _suppliersRepository.GetSupplierById(id);

            if(supplier == null)
            {
                return null;
            }

            return supplier.ToSupplierResponse();
        }

        public async Task<IEnumerable<SupplierResponse?>> GettAllSuppliers()
        {
            var suppliers= await
            _suppliersRepository.GetAllSuppliers();

            return
            suppliers.Select(su => su.ToSupplierResponse()).ToList();
        }

        public async Task<bool> UpdateSupplier(SupplierUpdateRequest supplierUpdateRequest)
        {
            var existingSupplier = await _suppliersRepository.GetSupplierById(supplierUpdateRequest.SupplierID);
            if (existingSupplier == null)
                return false;

            // تحديث الحقول يدويًا
            existingSupplier.Name = supplierUpdateRequest.Name ?? existingSupplier.Name;
            existingSupplier.Email = supplierUpdateRequest.Email ?? existingSupplier.Email;
            existingSupplier.Phone = supplierUpdateRequest.Phone ?? existingSupplier.Phone;

            return await _suppliersRepository.UpdateSupplier(existingSupplier);
        }

    }
}
