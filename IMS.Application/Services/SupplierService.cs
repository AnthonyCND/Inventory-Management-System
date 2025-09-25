using AutoMapper;
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
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISuppliersRepository suppliersRepository, IMapper mapper)
        {
            _suppliersRepository = suppliersRepository;
            _mapper = mapper;
        }

        public Task<bool> AddSupplier(SupplierDTO supplierDTO)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDTO);
                var added = _suppliersRepository.AddSupplier(supplier);
                return added;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> DeleteSuppliers(int[] ids)
        {
            try
            {
                return _suppliersRepository.DeleteSuppliers(ids);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SupplierDTO>> GetAllSuppliers()
        {
            try
            {
                List<Supplier> suppliers = await _suppliersRepository.GetAllSuppliers();
                if (suppliers == null)
                    return null;

                return _mapper.Map<List<SupplierDTO>>(suppliers);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SupplierDTO> GetSupplier(int id)
        {
            try
            {
                var supplier = await _suppliersRepository.GetSupplier(id);
                if (supplier == null)
                {
                    return null;
                }
                return _mapper.Map<SupplierDTO>(supplier);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> UpdateSupplier(SupplierDTO supplierDTO)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDTO);
                return _suppliersRepository.UpdateSupplier(supplier);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
