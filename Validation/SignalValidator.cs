using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation;

class SignalValidator : BaseValidator
{
    protected override ValidationResult ValidateSpecificFields(Report report)///Specific Fields Check Function
    {
        var signalReport = report as SignalReport;
        if (typeof(SignalReport) != report.GetType())
        {
            return ValidationResult.Failure("Invalid report type. Must be: SignalReport");
        }
        else if(signalReport.Frequency < 1.0 || signalReport.Frequency > 3000.0)
        {
            return ValidationResult.Failure("Invalid Frequency: Must be between 1.0 and 3000.0");
        }
        else if (string.IsNullOrEmpty(signalReport.Content))
        {
            return ValidationResult.Failure("Missing required field: Content");
        }
        else if (signalReport.Content.Length < 5 || signalReport.Content.Length > 1000)
        {
            return ValidationResult.Failure("Invalid Content: Must be between 5 and 1000 characters");
        }
        else if (!Enum.IsDefined(typeof(Language), signalReport.Language))
        {
            return ValidationResult.Failure("Invalid Language. Must be: Hebrew or Arabic or English or Russian or Other");
        }
        else if (signalReport.SignalStrength < -120 ||  signalReport.SignalStrength > 0)
        {
            return ValidationResult.Failure("Invalid SignalStrength: Must be between -120 and 0");
        }
        return ValidationResult.Success();
    }
}