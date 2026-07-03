using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation;
class DroneValidator : BaseValidator
{
    protected override ValidationResult ValidateSpecificFields(Report report)///Specific Fields Check Function.
    {
        var dronereport = report as DroneReport;
        if (typeof(DroneReport) != report.GetType())
        {
            return ValidationResult.Failure("Invalid report type. Must be: DroneReport");
        }
        if(dronereport.Altitude < 100 || dronereport.Altitude > 10000)
        {
            return ValidationResult.Failure("Invalid Altitude: Must be between 100 and 10000");
        }
        if(dronereport.ImageQuality < 1 || dronereport.ImageQuality > 100)
        {
            return ValidationResult.Failure("Invalid ImageQuality: Must be between 1 and 100");
        }
        return ValidationResult.Success();
    }
}