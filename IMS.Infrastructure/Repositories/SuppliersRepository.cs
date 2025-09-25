using AutoMapper;
using IMS.Application.DTOs;
using IMS.Application.Interfaces;
using IMS.Domain.Entities;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.EFModels;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SuppliersRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddSupplier(Supplier supplier)
        {
            try
            {
                var supplierEF = _mapper.Map<SupplierEF>(supplier);
                await _context.Suppliers.AddAsync(supplierEF);
                var added = await _context.SaveChangesAsync() > 0;
                return added;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteSuppliers(int[] ids)
        {
            if (ids == null || ids.Length == 0)
                return false;

            try
            {
                var suppliers = _context.Suppliers.Where(s => ids.Contains(s.SupplierId));
                _context.Suppliers.RemoveRange(suppliers);
                var deleted = await _context.SaveChangesAsync() > 0;
                return deleted;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            try
            {
                var lSuppliers = await _context.Suppliers.ToListAsync();
                if (lSuppliers == null)
                {
                    return null;
                }
                return _mapper.Map<List<Supplier>>(lSuppliers);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            try
            {
                var supplierEf = await _context.Suppliers.FindAsync(id).AsTask();
                if (supplierEf == null)
                {
                    return null;
                }
                return _mapper.Map<Supplier>(supplierEf);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            try
            {
                var supplerEF = await _context.Suppliers.FindAsync(supplier.Id);
                if (supplerEF == null)
                {
                    return false;
                }

                if(!string.IsNullOrEmpty(supplier.Name))
                    supplerEF.SupplierName = supplier.Name;

                if (!string.IsNullOrEmpty(supplier.Address))
                    supplerEF.Address = supplier.Address;

                if(!string.IsNullOrEmpty(supplier.Description))
                    supplerEF.Description = supplier.Description;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
