using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Znake.Auxiliary.Validation
{
    public class SaisieValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                return ((string) value).Length < 0 ? new ValidationResult(false, "Veuillez spécifier le champ.") : ValidationResult.ValidResult;
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }
        }
    }
}
