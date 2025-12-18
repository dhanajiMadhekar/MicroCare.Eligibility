using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEligibilityRepository
    {
        Task<IEnumerable<EligibilityRequest>> GetAllAsync(EligibilitySearchDto search);
        Task<EligibilityRequest?> GetByIdAsync(int id);
        Task<EligibilityRequest> AddAsync(EligibilityRequest request);
        Task DeleteAsync(int id);
    }
}
