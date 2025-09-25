using IMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierDTO> GetSupplier(int id);
        Task<List<SupplierDTO>> GetAllSuppliers();
        Task<bool> AddSupplier(SupplierDTO supplierDTO);
        Task<bool> UpdateSupplier(SupplierDTO supplierDTO);
        Task<bool> DeleteSuppliers(int[] ids);
    }
}
