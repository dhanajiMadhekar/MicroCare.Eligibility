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
        public string? PolicyNumber { get; set; }

        public bool IsNewBorn { get; set; }
        public bool IsReferral { get; set; }
    }
}
