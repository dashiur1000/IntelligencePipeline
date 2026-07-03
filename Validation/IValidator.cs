using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation;
interface IValidator///Requires building a function with the same signature.
{
    ValidationResult Validate(Report report);
}