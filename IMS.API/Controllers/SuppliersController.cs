using IMS.Application.DTOs;
using IMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _Service;

        public SuppliersController(ISupplierService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var lSupplierDTOs = await _Service.GetAllSuppliers();
            if (lSupplierDTOs.Count > 0)
                return Ok(lSupplierDTOs);
            return NotFound("No records found");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierDetails(int id)
        {
            SupplierDTO supplierDTO = await _Service.GetSupplier(id);
            if (supplierDTO != null)
                return Ok(supplierDTO);
            return NotFound("No record found");
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(SupplierDTO supplerDTO)
        {
           bool added = await _Service.AddSupplier(supplerDTO);
           if (added)
                return Created();
           return BadRequest("Invalid inputs");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSupplier(SupplierDTO supplerDTO) 
        {
            bool updated = await _Service.UpdateSupplier(supplerDTO);
            if (updated)
                return NoContent();
            return BadRequest("Invalid inputs");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSupplier([FromQuery] int[] ids)
        {
            if(ids == null || ids.Length == 0)
                return BadRequest("No supplier IDs provided");
            bool deleted = await _Service.DeleteSuppliers(ids);
            if (deleted)
                return NoContent();
            return NotFound("No suppliers matched the provided IDs");
        }
    }
}
