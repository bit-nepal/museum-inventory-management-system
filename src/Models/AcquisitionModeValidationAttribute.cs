
using System;
using System.ComponentModel.DataAnnotations;
namespace mims.Models;

public class AcquisitionModeValidationAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
  {
    if (value == null || Enum.IsDefined(typeof(AcquisitionMode), value))
    {
      return ValidationResult.Success;
    }

    return new ValidationResult($"Invalid acquisition mode: {value}");
  }
}
