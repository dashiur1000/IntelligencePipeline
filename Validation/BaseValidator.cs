using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System;
namespace IntelligencePipeline.Validation;
abstract class BaseValidator : IValidator
{
    private DateTime minDate = new DateTime(2020, 1, 1);///Current time variable
    public ValidationResult Validate(Report report)///Runs the "" function and returns an error or runs the specific field check function.
    {
        var commonResult = ValidateCommonFields(report);///Calls the "ValidateCommonFields" function
        if (!commonResult.IsValid)///It is not "" and therefore immediately returns the error message
        {
            return commonResult;
        }
        return ValidateSpecificFields(report);///It passed all the tests and therefore moves on to the tests of the specific fields.
    }
    protected ValidationResult ValidateCommonFields(Report report)///Checks the validity of the base fields in the message and inserts them into "ValidationResult".
    {
        if (report.Timestamp >  DateTime.Now)
        {
            return ValidationResult.Failure("Invalid Timestamp: cannot be in the future.");
        }
        if(report.Timestamp < minDate)
        {
            return ValidationResult.Failure("Invalid Timestamp: It is not possible to set a time before 2020-01-01.");
        }
        if(report.Latitude < 29.5000 || report.Latitude > 33.5000)
        {
            return ValidationResult.Failure("Invalid latitude: must be between 29.5000 and 33.5000");
        }
        if (report.Longitude < 34.0000 || report.Longitude > 36.0000)
        {
            return ValidationResult.Failure("Invalid longitude: must be between 34.0000 and 36.0000");
        }
        if (string.IsNullOrEmpty(report.Description))
        {
            return ValidationResult.Failure("Missing required field: Description");
        }
        if(report.Description.Length < 10 || report.Description.Length > 500)
        {
            return ValidationResult.Failure("Invalid description: must be between 10 and 500 characters");
        }
        return ValidationResult.Success();
    }
    protected abstract ValidationResult ValidateSpecificFields(Report report);///Requirement to build a function to check specific fields in the inheriting class.
}