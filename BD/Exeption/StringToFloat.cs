using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BD.Exeption
{
    class StringToFloat : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            float i;
            string str = value.ToString();             
            if (Single.TryParse(str, out i)) 
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Пожалуйста, введите численное значение.");
        }
    }
}
