using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateEligibilityDto
    {
        public string Payer { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;

        public string PatientName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string PolicyHolderName { get; set; } = string.Empty;
        public string? PolicyNumber { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }

        public string? ClassName { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? MobileNumber { get; set; }
        public string? MRN { get; set; }
        public decimal? ApprovalLimit { get; set; }
        public decimal? Deductibles { get; set; }
        public bool IsNewBorn { get; set; }
        public bool IsReferral { get; set; }
        public string? Purpose { get; set; }
        public string? Status { get; set; }
    }
}
