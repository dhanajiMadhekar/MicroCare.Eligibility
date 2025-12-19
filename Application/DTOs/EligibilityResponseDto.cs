using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EligibilityResponseDto
    {
        public int Id { get; set; }
        public string Payer { get; set; } = string.Empty;
        public string RequestDate { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public string PatientName { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public bool IsNewBorn { get; set; }
        public bool IsReferral { get; set; }

        public string PolicyHolderName { get; set; } = string.Empty;
        public string? PolicyNumber { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }

        public string MRN { get; set; } = string.Empty;
        public decimal? ApprovalLimit { get; set; }
        public decimal? Deductibles { get; set; }
        public string Purpose { get; set; } = string.Empty;

        public DateTime? PayerResponseDate { get; set; }
        public string? PayerResponseMessage { get; set; }
    }
}
