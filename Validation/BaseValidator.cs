using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;
using System;
namespace IntelligencePipeline.Validation;
abstract class BaseValidator : IValidator
{
    private DateTime minDate = new DateTime(2020, 1, 1);
    public ValidationResult Validate(Report report)
    {
        var commonResult = ValidateCommonFields(report);
        if(!commonResult.IsValid)
        {
            return commonResult;
        }
        return ValidateSpecificFields(report);
    }
    protected ValidationResult ValidateCommonFields(Report report)
    {
        if(report.Timestamp >  DateTime.Now)
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
        //if (report.GetType() != typeof(DroneReport) && report.GetType() != typeof(SoldierReport) && report.GetType() != typeof(RadarReport) && report.GetType() != typeof(SignalReport))
        //{
        //    return ValidationResult.Failure("Invalid report type. Must be: (DroneReport or SoldierReport or RadarReport or SignalReport)");
        //}
            return ValidationResult.Success();
    }
    protected abstract ValidationResult ValidateSpecificFields(Report report);
}