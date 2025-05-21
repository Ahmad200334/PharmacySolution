using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Domain.Entities.IdentityEntities;
using Pharmacy.Core.DTO.EmployeeDTO;
using Pharmacy.Core.DTO.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.IServiceContracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetAllAsync();

        Task<EmployeeResponse?> GetByIdAsync(int id);
        
        Task<EmployeeResponse?> GetByUserIdAsync(Guid userId);
        
        Task<EmployeeResponse> CreateAsync(EmployeeAddRequest request);
        
        Task<bool> UpdateAsync(EmployeeUpdateRequest request);
        
        Task<bool> DeleteAsync(int id);
    }
}
