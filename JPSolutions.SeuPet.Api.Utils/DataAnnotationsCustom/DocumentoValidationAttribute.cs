using System.ComponentModel.DataAnnotations;

namespace JPSolutions.SeuPet.Api.Utils.DataAnnotationsCustom
{
    public class DocumentoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string documento = (string)value;
            if (Validations.IsCpf(documento) || Validations.IsCnpj(documento))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage.Replace("{0}", validationContext.DisplayName));
        }
    }
}
