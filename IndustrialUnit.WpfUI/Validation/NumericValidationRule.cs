﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IndustrialUnit.WpfUI.Validation
{
  public class NumericValidationRule : ValidationRule
  {
    public int MinimumCharacters { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
   {
      string charString = value as string;

    if (charString.Any(char.IsLetter))
        return new ValidationResult(false, "Only number is allowed.");
      else if (charString.Length < MinimumCharacters && !string.IsNullOrWhiteSpace(charString))
        return new ValidationResult(false, $"Label must consist at least {MinimumCharacters} char.");
      else if (string.IsNullOrWhiteSpace(charString))
        return new ValidationResult(false, $"Label cannot be empty.");
      else if (charString.EndsWith(","))
        return new ValidationResult(false, $"Use dot.");
      else if (charString.Contains(" "))
        return new ValidationResult(false, $"Space is not allowed.");

      return new ValidationResult(true, null);
    }
  }
}
