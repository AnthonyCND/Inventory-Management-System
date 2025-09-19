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
        Supplier GetSupplier(int id);
        List<Supplier> GetAllSuppliers();
        bool AddSupplier(Supplier supplier);
        bool UpdateSupplier(Supplier supplier);
        bool DeleteSuppliers(int[] ids);
    }
}
