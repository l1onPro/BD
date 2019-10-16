using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BD.Exeption
{
    class IsNotNull : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Пустая строка, введите значение.");
        }
    }
}
