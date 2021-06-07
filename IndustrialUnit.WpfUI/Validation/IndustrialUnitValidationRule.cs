using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IndustrialUnit.WpfUI.Validation
{
  public class IndustrialUnitValidationRule : ValidationRule
  {
    public int MinimumCharacters { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      string charString = value as string;

      if (charString.Length < MinimumCharacters && !string.IsNullOrWhiteSpace(charString))
        return new ValidationResult(false, $"Label must consist at least {MinimumCharacters} char.");
      else if (string.IsNullOrWhiteSpace(charString))
        return new ValidationResult(false, "");

      return new ValidationResult(true, null);
    }
  }
}
