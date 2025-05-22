using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Domain.Entities;
using Pharmacy.Core.DTO.SupplierDTO;
using Pharmacy.Core.IServiceContracts;

namespace Pharmacy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }



        // GET: api/Suppliers
        [HttpGet]
        public async Task<IEnumerable<SupplierResponse>> GetAllSuppliers()
        {
            return await _supplierService.GettAllSuppliers();
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierResponse>> GetSupplier(int id)
        {
            var supplierResponse = await _supplierService.GetsupplierById(id);

            if (supplierResponse == null)
            {
                return NotFound();
            }

            return supplierResponse;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, SupplierUpdateRequest request)
        {
            if (request == null || id != request.SupplierID)
                return BadRequest();

            var result = await _supplierService.UpdateSupplier(request);

            if (!result)
                return NotFound();

            return Ok(result);
        }



        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supplier>> AddSupplier(SupplierAddRequest supplierAddRequest)
        {
            var supplierResponse = await _supplierService.AddSupplier(supplierAddRequest);

            if (supplierResponse == null)
            {
                return BadRequest(); // أو Problem()
            }

 

            return CreatedAtAction("GetSupplier", new { id = supplierResponse.SupplierId }, supplierResponse);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {

            var result =
            await _supplierService.DeleteSupplier(id);

            if (!result)
            {
                return Problem();
            }


            return Ok(result);
        }


    }
}
