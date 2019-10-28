﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BD.Exeption
{
    class IsNotNullValue : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            float i;
            if (Single.TryParse(value.ToString(), out i))
                if (i != 0) return new ValidationResult(true, null);

            return new ValidationResult(false, "Пожалуйста, введите число != 0");
        }
    }
}
