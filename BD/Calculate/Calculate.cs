using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.ViewModels;

namespace BD.Calculate
{
    class Calculate
    {
        public void CalculateAlg()
        {
            //обнуление массивов 
            Nullarrays();

            form_r();
        }

        private void Nullarrays()
        {
            for (int i = 0; i <ViewModel.M; i++)
            {
                for (int j = 0; j < ViewModel.M; j++)
                {
                    ViewModel.a[i, j] = 0;
                    ViewModel.b[i, j] = 0;
                }
            }
        }   

        private void form_r()
        {
            for (int kd = 0; kd < ViewModel.listR.Count; kd++)
            {
                for (int l = 0; l <= 1; l++)
                {
                    int i = ViewModel.listR[kd].in_el[l];
                    if (i == 0) continue;
                    for (int m = 0; m <= 1; m++)
                    {
                        int j = ViewModel.listR[kd].in_el[m];
                        if (j == 0) continue;
                        int g = (1 - 2 * l) * (1 - 2 * m);
                        ViewModel.a[i, j] += g / ViewModel.listR[kd].Z;
                    }
                }  
            }
        }

    }
}
