using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEligibilityService
    {
        Task<IEnumerable<EligibilityResponseDto>> SearchAsync(EligibilitySearchDto search);
        Task<EligibilityResponseDto?> GetByIdAsync(int id);
        Task<EligibilityResponseDto> CreateAsync(CreateEligibilityDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
