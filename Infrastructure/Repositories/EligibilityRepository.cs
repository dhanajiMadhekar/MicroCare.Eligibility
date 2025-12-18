using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EligibilityRepository : IEligibilityRepository
    {
        private readonly ApplicationDbContext _context;

        public EligibilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EligibilityRequest>> GetAllAsync(EligibilitySearchDto search)
        {
            var query = _context.EligibilityRequests.AsQueryable();

            if (!string.IsNullOrEmpty(search.Payer))
                query = query.Where(x => x.Payer == search.Payer);
            if (search.FromDate.HasValue)
                query = query.Where(x => x.RequestDate >= search.FromDate.Value);
            if (search.ToDate.HasValue)
                query = query.Where(x => x.RequestDate <= search.ToDate.Value);
            if (!string.IsNullOrEmpty(search.Status))
                query = query.Where(x => x.Status.ToString() == search.Status);
            if (!string.IsNullOrEmpty(search.PatientName))
                query = query.Where(x => x.PatientName.Contains(search.PatientName));

            return await query.OrderByDescending(x => x.RequestDate).ToListAsync();
        }

        public async Task<EligibilityRequest?> GetByIdAsync(int id)
        {
            return await _context.EligibilityRequests.FindAsync(id);
        }

        public async Task<EligibilityRequest> AddAsync(EligibilityRequest request)
        {
            _context.EligibilityRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.EligibilityRequests.FindAsync(id);
            if (entity != null)
            {
                _context.EligibilityRequests.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
