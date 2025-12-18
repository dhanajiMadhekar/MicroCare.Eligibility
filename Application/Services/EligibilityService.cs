using Application.DTOs;
using Application.Interfaces;
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

        public EligibilityService(IEligibilityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EligibilityResponseDto>> SearchAsync(EligibilitySearchDto search)
        {
            var entities = await _repository.GetAllAsync(search);

            return entities.Select(e => MapToDto(e));
        }

        public async Task<EligibilityResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return MapToDto(entity);
        }

        public async Task<EligibilityResponseDto> CreateAsync(CreateEligibilityDto dto)
        {
            var entity = new EligibilityRequest
            {
                Payer = dto.Payer,
                RequestDate = DateTime.Now,
                Status = RequestStatus.Pending,
                PatientName = dto.PatientName,
                DocumentType = dto.DocumentType,
                DocumentNumber = dto.DocumentNumber,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                PolicyHolderName = dto.PolicyHolderName,
                PolicyNumber = dto.PolicyNumber,
                MaritalStatus = dto.MaritalStatus,
                MobileNumber = dto.MobileNumber,
                IsReferral = dto.IsReferral,
                IsNewBorn = dto.IsNewBorn,
                ClassName = dto.ClassName,
                ExpiryDate = dto.ExpiryDate,
                MRN = dto.MRN,
                ApprovalLimit = dto.ApprovalLimit,
                Deductibles = dto.Deductibles,
                Purpose = dto.Purpose,
                CreatedDate = DateTime.Now
            };

            var savedEntity = await _repository.AddAsync(entity);

            return MapToDto(savedEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }

        private static EligibilityResponseDto MapToDto(EligibilityRequest entity)
        {
            return new EligibilityResponseDto
            {
                Id = entity.Id,
                Payer = entity.Payer,
                RequestDate = entity.RequestDate.ToString("yyyy-MM-dd"),
                Status = entity.Status.ToString(),
                PatientName = entity.PatientName,
                DocumentType = entity.DocumentType,
                DocumentNumber = entity.DocumentNumber,
                PolicyNumber = entity.PolicyNumber,
                IsNewBorn = entity.IsNewBorn ?? false,
                IsReferral = entity.IsReferral ?? false
            };
        }
    }
}
