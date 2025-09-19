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
        public IActionResult GetSuppliers() 
        {
            List<SupplierDTO> supplierDTOs = _Service.GetAllSuppliers();
            if (supplierDTOs.Count > 0)
                return Ok(supplierDTOs);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetSupplierDetails(int id)
        {
            SupplierDTO supplierDTO = _Service.GetSupplier(id);
            if (supplierDTO != null)
                return Ok(supplierDTO);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddSupplier(SupplierDTO supplerDTO)
        {
           bool added = _Service.AddSupplier(supplerDTO);
           if (added)
                return Created();
           return BadRequest();
        }

        [HttpPatch]
        public IActionResult UpdateSupplier(SupplierDTO supplerDTO) 
        {
            bool updated = _Service.UpdateSupplier(supplerDTO);
            if (updated)
                return NoContent();
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult RemoveSupplier(int[] ids)
        {
            bool deleted = _Service.DeleteSuppliers(ids);
            if (deleted)
                return NoContent();
            return BadRequest();
        }
    }
}
