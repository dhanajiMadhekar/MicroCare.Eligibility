using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace MicroCare.Tests
{
    public class EligibilityServiceTests
    {
        private readonly Mock<IEligibilityRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EligibilityService _service;

        public EligibilityServiceTests()
        {
            _mockRepo = new Mock<IEligibilityRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new EligibilityService(_mockRepo.Object, _mockMapper.Object);
        }


        [Fact]
        public async Task CreateAsync_Should_Set_Defaults_And_Call_Repository()
        {
            // Arrange
            var dto = new CreateEligibilityDto { PatientName = "Test Patient", Payer = "Medgulf" };
            var entity = new EligibilityRequest { PatientName = "Test Patient" };
            var savedEntity = new EligibilityRequest { Id = 1, PatientName = "Test Patient", Status = RequestStatus.Pending };
            var responseDto = new EligibilityResponseDto { Id = 1, Status = "Pending" };

            _mockMapper.Setup(m => m.Map<EligibilityRequest>(dto)).Returns(entity);

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<EligibilityRequest>()))
                     .ReturnsAsync(savedEntity);

            _mockMapper.Setup(m => m.Map<EligibilityResponseDto>(savedEntity)).Returns(responseDto);

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Pending", result.Status);

            Assert.Equal(RequestStatus.Pending, entity.Status);

            _mockRepo.Verify(r => r.AddAsync(It.IsAny<EligibilityRequest>()), Times.Once);
        }


        [Fact]
        public async Task GetByIdAsync_Should_Return_Dto_When_Found()
        {
            // Arrange
            var entity = new EligibilityRequest { Id = 1, PatientName = "John Doe" };
            var responseDto = new EligibilityResponseDto { Id = 1, PatientName = "John Doe" };

            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(entity);
            _mockMapper.Setup(m => m.Map<EligibilityResponseDto>(entity)).Returns(responseDto);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((EligibilityRequest?)null);

            // Act
            var result = await _service.GetByIdAsync(99);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task UpdateAsync_Should_Throw_KeyNotFound_If_Id_Does_Not_Exist()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((EligibilityRequest?)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _service.UpdateAsync(99, new CreateEligibilityDto()));
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Entity_And_Save()
        {
            // Arrange
            var existingEntity = new EligibilityRequest { Id = 1, Status = RequestStatus.Pending };
            var updateDto = new CreateEligibilityDto { Status = "Approved" };
            var updatedDto = new EligibilityResponseDto { Id = 1, Status = "Approved" };

            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingEntity);

            _mockMapper.Setup(m => m.Map(updateDto, existingEntity))
                       .Callback<CreateEligibilityDto, EligibilityRequest>((src, dest) => dest.Status = RequestStatus.Approved);

            _mockMapper.Setup(m => m.Map<EligibilityResponseDto>(existingEntity)).Returns(updatedDto);

            // Act
            var result = await _service.UpdateAsync(1, updateDto);

            // Assert
            Assert.Equal("Approved", result.Status);

            Assert.NotNull(existingEntity.ModifiedDate);

            _mockRepo.Verify(r => r.UpdateAsync(existingEntity), Times.Once);
        }

        // --- DELETE TESTS ---

        [Fact]
        public async Task DeleteAsync_Should_Call_Repository_Delete()
        {
            // Arrange
            _mockRepo.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _service.DeleteAsync(1);

            // Assert
            Assert.True(result);
            _mockRepo.Verify(r => r.DeleteAsync(1), Times.Once);
        }
    }
}