using BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.ViewModels
{
    interface Frequency
    {       
        string GetTypeLaw();       
        void SetListF();
    }

    class Single_frequency_point : Frequency
    {
        public Single_frequency_point()
        {
            F_min = 0;
        }
        public float F_min { get; set; }
        public string GetTypeLaw()
        {
            return "Single_frequency_point";
        }
       
        public void SetListF()
        {
            ViewModel.F = new List<float>();
            ViewModel.F.Add(F_min);
        }
    }
    class Linear_law : Frequency
    {
        public Linear_law()
        {
            F_min = 0;
            F_max = 0;
            Df = 0;
        }
        public float F_min { get; set; }
        public float F_max { get; set; }
        public float Df { get; set; }
        public string GetTypeLaw()
        {
            return "Linear_law";
        }
        public float Next(float cur)
        {
            return cur + Df;
        }       
        public void SetListF()
        {
            float cur = F_min;
            ViewModel.F = new List<float>();
            
            while (cur < F_max)
            {
                ViewModel.F.Add(cur);
                cur = Next(cur);
            }
        }
    }
    class Logarithmic_law : Frequency
    {
        public Logarithmic_law()
        {
            F_min = 0;
            F_max = 0;
            Df = 0;
        }
        public float F_min { get; set; }
        public float F_max { get; set; }
        public float Df { get; set; }
        public string GetTypeLaw()
        {
            return "Logarithmic_law";
        }
        public float Next(float cur)
        {
            return cur * Df;
        }       
        public void SetListF()
        {
            float cur = F_min;
            ViewModel.F = new List<float>();

            while (cur < F_max)
            {
                ViewModel.F.Add(cur);
                cur = Next(cur);
            }
        }
    }
}
