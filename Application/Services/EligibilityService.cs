using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EligibilityService : IEligibilityService
    {
        private readonly IEligibilityRepository _repository;
        private readonly IMapper _mapper;

        public EligibilityService(IEligibilityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EligibilityResponseDto>> SearchAsync(EligibilitySearchDto search)
        {
            var entities = await _repository.GetAllAsync(search);

            return _mapper.Map<IEnumerable<EligibilityResponseDto>>(entities);
        }

        public async Task<EligibilityResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return _mapper.Map<EligibilityResponseDto>(entity);
        }

        public async Task<EligibilityResponseDto> CreateAsync(CreateEligibilityDto dto)
        {
            var entity = _mapper.Map<EligibilityRequest>(dto);

            var savedEntity = await _repository.AddAsync(entity);

            return _mapper.Map<EligibilityResponseDto>(savedEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
