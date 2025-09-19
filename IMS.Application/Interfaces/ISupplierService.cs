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
        SupplierDTO GetSupplier(int id);
        List<SupplierDTO> GetAllSuppliers();
        bool AddSupplier(SupplierDTO supplierDTO);
        bool UpdateSupplier(SupplierDTO supplierDTO);
        bool DeleteSuppliers(int[] ids);
    }
}
