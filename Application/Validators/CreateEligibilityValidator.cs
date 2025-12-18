using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateEligibilityValidator : AbstractValidator<CreateEligibilityDto>
    {
        public CreateEligibilityValidator()
        {
            RuleFor(x => x.Payer)
                .NotEmpty().WithMessage("Payer is required.");

            RuleFor(x => x.PatientName)
                .NotEmpty().WithMessage("Patient Name is required.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("Document Number is required.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Date of Birth cannot be in the future.");

            RuleFor(x => x.MobileNumber)
                .Matches(@"^\+?[0-9]{7,15}$")
                .When(x => !string.IsNullOrEmpty(x.MobileNumber))
                .WithMessage("Mobile Number must be valid.");
        }
    }
}
