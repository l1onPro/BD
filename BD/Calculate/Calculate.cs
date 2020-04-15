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
            ViewModel.vGovno();
            ViewModel.om = 2 * 3.14 * ViewModel.f[1];
            form_d(ref ViewModel.in_r, ref ViewModel.z_r, ViewModel.NR, 'R');
            form_d(ref ViewModel.in_c, ref ViewModel.z_c, ViewModel.NC, 'C');
            form_d(ref ViewModel.in_l, ref ViewModel.z_l, ViewModel.NL, 'L');
            form_w();
            st();

            sf1(1);
            sf2(1);
            
            /*for (int kf = 0; kf < ViewModel.F.Count; kf++)
            {
                ViewModel.s = new Complex(0.0, );
                //обнуление массивов 
                NullArrays();

                ViewModel.N = ViewModel.NV;
                

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
            }       */
        }
        public static void form_d(ref int[,] in_d, ref double[] z_d, int nd, char td)
        {
            int i, j, l, m, g;
            if (td != 'L')
                for (int kd = 1; kd <= nd; kd++)
                    for (l = 0; l <= 1; l++)
                    {
                        i = in_d[kd, l];
                        if (i == 0) continue;
                        for (m = 0; m <= 1; m++)
                        {
                            j = in_d[kd, m];
                            if (j == 0) continue;
                            g = (1 - 2 * l) * (1 - 2 * m);
                            switch (td)
                            {
                                case 'R':
                                    ViewModel.a[i, j] += g / z_d[kd];
                                    break;
                                case 'C':
                                    ViewModel.b[i, j] += g * z_d[kd];
                                    break;
                            }
                        }
                    }
            else
            {
                for (int kd = 1; kd <= nd; kd++)
                {
                    i = ViewModel.n + kd;
                    ViewModel.b[i, i] = z_d[kd];
                    for (m = 0; m <= 1; m++)
                    {
                        j = in_d[kd, m];
                        if (j == 0) continue;
                        g = 1 - 2 * m;
                        ViewModel.a[i, j] -= g;
                        ViewModel.a[j, i] += g;
                    }
                }
                ViewModel.n += nd;
            }
        }
        public static void form_w()
        {
            int i, j;
            double t;
            for (i = 1; i <= ViewModel.n; i++)
                for (j = 1; j <= ViewModel.n; j++)
                {
                    t = ViewModel.b[i, j];
                    if (t != 0)
                        t *= ViewModel.om;
                    ViewModel.w[i, j] = new Complex(ViewModel.a[i, j], t);
                }
        }
        public static void st()
        {
            Complex c = new Complex(0, 0);
            Complex t = new Complex(0, 0);
            Complex cn = new Complex(0, 0);
            double g;
            int l;
            for (int k = ViewModel.n; k >= 3; k--)
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
                    for (int j = k; j <= ViewModel.n; j++)
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
        public static void sf1(int kf)
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
            for (k = 1; k < ViewModel.n; k++)
            {
                l = k;
                for (i = k + 1; i <= ViewModel.n; i++)
                    if (ViewModel.w[i, k].abs > ViewModel.w[l, k].abs)
                        l = i;
                if (l != k)
                    for (j = 0; j <= ViewModel.n; j++)
                        if (j == 0 || j >= k)
                        {
                            t = ViewModel.w[k, j];
                            ViewModel.w[k, j] = ViewModel.w[l, j];
                            ViewModel.w[l, j] = t;
                        }
                d = 1.0 / ViewModel.w[k, k];
                for (i = k + 1; i <= ViewModel.n; i++)
                {
                    if (ViewModel.w[i, k] == cn)
                        continue;
                    c = ViewModel.w[i, k] * d;
                    for (j = k + 1; j <= ViewModel.n; j++)
                        if (ViewModel.w[k, j] != cn)
                            ViewModel.w[i, j] = ViewModel.w[i, j] - c * ViewModel.w[k, j];
                    if (ViewModel.w[k, 0] != cn)
                        ViewModel.w[i, 0] = ViewModel.w[i, 0] - c * ViewModel.w[k, 0];
                }
            }
            ViewModel.w[0, ViewModel.n] = -ViewModel.w[ViewModel.n, 0] / ViewModel.w[ViewModel.n, ViewModel.n];
            for (i = ViewModel.n - 1; i >= 1; i--)
            {
                t = ViewModel.w[i, 0];
                for (j = i + 1; j <= ViewModel.n; j++)
                    t = t + ViewModel.w[i, j] * ViewModel.w[0, j];
                ViewModel.w[0, i] = -t / ViewModel.w[i, i];
            }
        }

        public static void sf2(int kf)
        {
            Complex ku = new Complex(0, 0);
            Complex ri = new Complex(0, 0);
            ri = ViewModel.w[1, ViewModel.lp] - ViewModel.w[1, ViewModel.lm];
            ku = (ViewModel.w[1, ViewModel.kp] - ViewModel.w[1, ViewModel.km]) / ri;
            ViewModel.kum[kf] = (float)ku.abs;
            ViewModel.kua[kf] = (float)ku.arg * 180.0f / (float)Math.PI;
            ViewModel.rim[kf] = (float)ri.abs;
            ViewModel.ria[kf] = (float)ri.arg * 180.0f / (float)Math.PI;
        }
    }
}
