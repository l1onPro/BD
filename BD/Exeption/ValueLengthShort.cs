using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BD.Exeption
{
    class ValueLengthShort : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value.ToString().Length < 3)
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Слишком большое кол-во символов.");
        }
    }
}
