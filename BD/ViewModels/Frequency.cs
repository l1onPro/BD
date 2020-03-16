using BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.ViewModels
{
    class Frequency
    {
        public static Laws TypeLaw { get; set; } = Laws.Single_frequency_point;
        public static double F_min { get; set; } = 0;
        public static double F_max { get; set; } = 0;
        public static double Df { get; set; } = 0.1;

        public Frequency(bool Default = false)
        {
            if (Default)
            {
                F_min = 0;
                F_max = 0;
                Df = 0.1;
            }
        }

        public static void SetListF()
        {
            ViewModel.F = new List<double>();
            double cur = F_min;
            switch (TypeLaw)
            {
                case Laws.Single_frequency_point:                    
                    ViewModel.F.Add(cur);
                    break;
                case Laws.Linear_law: 
                    while (cur < F_max)
                    {
                        ViewModel.F.Add(cur);
                        cur = Next(cur);
                    }
                    break;
                case Laws.Logarithmic_law:  
                    while (cur < F_max)
                    {
                        ViewModel.F.Add(cur);
                        cur = Next(cur);
                    }
                    break;
                default:
                    break;
            }            
        }
        public static double Next(double cur)
        {
            switch (TypeLaw)
            {
                case Laws.Single_frequency_point:
                    break;
                case Laws.Linear_law:
                    return cur + Df;
                case Laws.Logarithmic_law:
                    return cur * Df;
                default:
                    break;
            }
            throw new Exception();
        }
    }    
}
