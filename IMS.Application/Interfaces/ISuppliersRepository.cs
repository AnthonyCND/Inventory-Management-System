using IMS.Application.DTOs;
using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Interfaces
{
    public interface ISuppliersRepository
    {
        Task<Supplier> GetSupplier(int id);
        Task<List<Supplier>> GetAllSuppliers();
        Task<bool> AddSupplier(Supplier supplier);
        Task<bool> UpdateSupplier(Supplier supplier);
        Task<bool> DeleteSuppliers(int[] ids);
    }
}
