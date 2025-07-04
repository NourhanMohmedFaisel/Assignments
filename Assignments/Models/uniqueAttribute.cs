using Assignments.ModelView;
using System.ComponentModel.DataAnnotations;

namespace Assignments.Models
{
    public class uniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string nameFromREquest = value.ToString();
            CourseDetailsViewModel CourseFromRequest =
               (CourseDetailsViewModel)validationContext.ObjectInstance;

            ITIContext context = new ITIContext();

            Course CourseFromDB
                = context.Course
                .FirstOrDefault(c =>
                c.Name == nameFromREquest && c.DepartmentID == CourseFromRequest.DepartmentID);

            if (CourseFromDB == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("NAme Already Exist!!! :(");
        }
    }
    }

