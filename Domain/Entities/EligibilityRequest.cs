using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EligibilityRequest
    {
        public int Id { get; set; }

        public string Payer { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public string PatientName { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }

        public string PolicyHolderName { get; set; } = string.Empty;
        public string? PolicyNumber { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }

        public string? MobileNumber { get; set; }
        public bool IsReferral { get; set; }
        public bool IsNewBorn { get; set; }

        public DateTime? PayerResponseDate { get; set; }
        public string? PayerResponseMessage { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
    }
}
