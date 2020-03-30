using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Models;
using BD.ViewModels;

namespace BD.Calculate
{
    class Calculate
    {
        public void CalculateAlg()
        {
            //обнуление массивов 
            NullArrays();

            ViewModel.N = ViewModel.NV;
            form_d(ViewModel.listR);
            form_d(ViewModel.listC);
            form_d(ViewModel.listL);

            for (int kf = 0; kf < ViewModel.F.Count; kf++)
            {
                ViewModel.om = 2 * 3.141593 * ViewModel.F[kf];
                
                form_w();
                form_s();

                if ((Nodes.lp == 1) && (Nodes.lm == 0) && (Nodes.kp == 2) && (Nodes.km == 0))
                {
                    st();
                    sf1(kf);
                }
                else
                {
                    gauss_c();
                    sf2(kf);
                }
            }            
        }

        private void NullArrays()
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
        
        /// <summary>
        /// Формирование вещественных частотно-независимых матриц
        /// </summary>
        private void form_d(List<R> listEl)
        {
            for (int kd = 0; kd < listEl.Count; kd++)
            {
                for (int l = 0; l <= 1; l++)
                {
                    int i = listEl[kd].in_el[l];
                    if (i == 0) continue;
                    for (int m = 0; m <= 1; m++)
                    {
                        int j = listEl[kd].in_el[m];
                        if (j == 0) continue;
                        int g = (1 - 2 * l) * (1 - 2 * m);
                        ViewModel.a[i, j] += g / listEl[kd].Z;
                    }
                }  
            }
        }
        /// <summary>
        /// Формирование вещественных частотно-независимых матриц
        /// </summary>
        private void form_d(List<C> listEl)
        {
            for (int kd = 0; kd < listEl.Count; kd++)
            {
                for (int l = 0; l <= 1; l++)
                {
                    int i = listEl[kd].in_el[l];
                    if (i == 0) continue;
                    for (int m = 0; m <= 1; m++)
                    {
                        int j = listEl[kd].in_el[m];
                        if (j == 0) continue;
                        int g = (1 - 2 * l) * (1 - 2 * m);
                        ViewModel.a[i, j] += g * listEl[kd].Z;
                    }
                }
            }
        }
        /// <summary>
        /// Формирование вещественных частотно-независимых матриц
        /// </summary>
        private void form_d(List<L> listEl)
        {
            for (int kd = 0; kd < listEl.Count; kd++)
            {
                int i = ViewModel.N + kd + 1;
                ViewModel.b[i, i] = listEl[kd].Z;
                for (int m = 0; m < 1; m++)
                {
                    int j = listEl[kd].in_el[m];
                    if (j == 0) continue;
                    int g = 1 - 2 * m;
                    ViewModel.a[i, j] -= g;
                    ViewModel.a[i, j] += g;
                }
            }
            ViewModel.N += listEl.Count + 1;
        }
        private void form_w()
        {
            for (int i = 1; i < ViewModel.N; i++)
            {
                for (int j = 1; j < ViewModel.N; j++)
                {
                    double t = ViewModel.b[i, j];
                   if (t != 0)
                        t *= ViewModel.om;
                    ViewModel.w[i, j] = new Complex(ViewModel.a[i, j], t);
                }
            }
        }
        private void form_s()
        {
            for (int i = 1; i < ViewModel.N; i++)
            {
                ViewModel.w[i, 0] = new Complex(0, 0);
                if (Nodes.lp != 0)
                    ViewModel.w[Nodes.lp, 0] = new Complex(-1, 0);
                if (Nodes.lm != 0)
                    ViewModel.w[Nodes.lm, 0] = new Complex(1, 0);
            }
        }

        private void st()
        {
            Complex c = new Complex(0, 0);
            Complex t = new Complex(0, 0);
            Complex cn = new Complex(0, 0);
            double g;
            int l;
            for (int k = ViewModel.N; k >= 3; k--)
            {
                l = k;
                g = 0.001;
                while (ViewModel.w[l, k].abs <= g)
                {
                    l = l - 1;
                    if (l == 2)
                    {
                        l = k;
                        g = 0.1 * g;
                    }
                }
                if (l != k)
                    for (int j = k; j <= ViewModel.N; j++)
                    {
                        t = ViewModel.w[k, j];
                        ViewModel.w[k, j] = ViewModel.w[l, j];
                        ViewModel.w[l, j] = t;
                    }
                for (int i = k - 1; i >= 1; i--)
                {
                    if (ViewModel.w[i, k] == cn)
                        continue;
                    c = ViewModel.w[i, k] / ViewModel.w[k, k];
                    for (int j = 1; j <= k - 1; j++)
                        if (ViewModel.w[k, j] != cn)
                            ViewModel.w[i, j] -= c * ViewModel.w[k, j];
                }
            }
        }
        private void sf1(int kf)
        {
            Complex ku = new Complex(0, 0);
            Complex ri = new Complex(0, 0);
            Complex ro = new Complex(0, 0);
            Complex d = new Complex(0, 0);
            ku = -ViewModel.w[2, 1] / ViewModel.w[2, 2];
            d = ViewModel.w[1, 1] * ViewModel.w[2, 2] - ViewModel.w[2, 1] * ViewModel.w[1, 2];
            ri = ViewModel.w[2, 2] / d;
            ro = ViewModel.w[1, 1] / d;
            ViewModel.kum[kf] = (float)ku.abs;
            ViewModel.kua[kf] = (float)ku.arg * 180.0f / (float)Math.PI;
            ViewModel.rim[kf] = (float)ri.abs;
            ViewModel.ria[kf] = (float)ri.arg * 180.0f / (float)Math.PI;
            ViewModel.rom[kf] = (float)ro.abs;
            ViewModel.roa[kf] = (float)ro.arg * 180.0f / (float)Math.PI;
        }

        private void gauss_c()
        {
            int i, j, k, l;
            Complex c = new Complex(0, 0);
            Complex d = new Complex(0, 0);
            Complex t = new Complex(0, 0);
            Complex cn = new Complex(0, 0);
            for (k = 1; k < ViewModel.N; k++)
            {
                l = k;
                for (i = k + 1; i <= ViewModel.N; i++)
                    if (ViewModel.w[i, k].abs > ViewModel.w[l, k].abs)
                        l = i;
                if (l != k)
                    for (j = 0; j <= ViewModel.N; j++)
                        if (j == 0 || j >= k)
                        {
                            t = ViewModel.w[k, j];
                            ViewModel.w[k, j] = ViewModel.w[l, j];
                            ViewModel.w[l, j] = t;
                        }
                d = 1.0 / ViewModel.w[k, k];
                for (i = k + 1; i <= ViewModel.N; i++)
                {
                    if (ViewModel.w[i, k] == cn)
                        continue;
                    c = ViewModel.w[i, k] * d;
                    for (j = k + 1; j <= ViewModel.N; j++)
                        if (ViewModel.w[k, j] != cn)
                            ViewModel.w[i, j] = ViewModel.w[i, j] - c * ViewModel.w[k, j];
                    if (ViewModel.w[k, 0] != cn)
                        ViewModel.w[i, 0] = ViewModel.w[i, 0] - c * ViewModel.w[k, 0];
                }
            }
            ViewModel.w[0, ViewModel.N] = -ViewModel.w[ViewModel.N, 0] / ViewModel.w[ViewModel.N, ViewModel.N];
            for (i = ViewModel.N - 1; i >= 1; i--)
            {
                t = ViewModel.w[i, 0];
                for (j = i + 1; j <= ViewModel.N; j++)
                    t = t + ViewModel.w[i, j] * ViewModel.w[0, j];
                ViewModel.w[0, i] = -t / ViewModel.w[i, i];
            }
        }
        private void sf2(int kf)
        {
            Complex ku = new Complex(0, 0);
            Complex ri = new Complex(0, 0);
            ri = ViewModel.w[0, Nodes.lp] - ViewModel.w[0, Nodes.lm];
            ku = (ViewModel.w[0, Nodes.kp] - ViewModel.w[0, Nodes.km]) / ri;
            ViewModel.kum[kf] = (float)ku.abs;
            ViewModel.kua[kf] = (float)ku.arg * 180.0f / (float)Math.PI;
            ViewModel.rim[kf] = (float)ri.abs;
            ViewModel.ria[kf] = (float)ri.arg * 180.0f / (float)Math.PI;
        }
    }
}
