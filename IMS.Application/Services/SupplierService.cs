using IMS.Application.DTOs;
using IMS.Application.Interfaces;
using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISuppliersRepository _SuppliersRepository;

        public SupplierService(ISuppliersRepository suppliersRepository)
        {
            _SuppliersRepository = suppliersRepository;
        }

        public bool AddSupplier(SupplierDTO supplierDTO)
        {
            Supplier supplier = new Supplier() 
            { 
                Name = supplierDTO.Name,
                Description = supplierDTO.Description,
            };
            return _SuppliersRepository.AddSupplier(supplier);
        }

        public bool DeleteSuppliers(int[] ids)
        {
            return _SuppliersRepository.DeleteSuppliers(ids);
        }

        public List<SupplierDTO> GetAllSuppliers()
        {
            List<Supplier> suppliers = _SuppliersRepository.GetAllSuppliers();
            if (suppliers == null)
                return new List<SupplierDTO>();
            
            return suppliers.Select(s => new SupplierDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                }
            ).ToList();
        }

        public SupplierDTO GetSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSupplier(SupplierDTO supplierDTO)
        {
            throw new NotImplementedException();
        }
    }
}
