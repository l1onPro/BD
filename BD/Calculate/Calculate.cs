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
            clear_w();

            for (int kf = 1; kf <= ViewModel.F.Count; kf++)
            {
                ViewModel.s = new Complex(0.0, 2 * Math.PI * ViewModel.f[kf]);

                form_d(ref ViewModel.in_r, ref ViewModel.z_r, ViewModel.NR, 'R');
                form_d(ref ViewModel.in_l, ref ViewModel.z_l, ViewModel.NL, 'L');
                form_d(ref ViewModel.in_c, ref ViewModel.z_c, ViewModel.NC, 'C');

                form_eu();
                form_ju();
                form_tri();

                form_s();


                if ((ViewModel.lp == 1) && (ViewModel.lm == 0) && (ViewModel.kp == 2) && (ViewModel.km == 0))
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
        void form_s()
        {
            if (ViewModel.lp != 0)
                ViewModel.w[ViewModel.lp, 0] = new Complex(-1, 0);
            if (ViewModel.lm != 0)
                ViewModel.w[ViewModel.lm, 0] = new Complex(1, 0);
        }

        void clear_w()
        {
            for (int row = 0; row <= ViewModel.M; row++)
            {
                for (int col = 0; col <= ViewModel.M; col++)
                {
                    ViewModel.w[row, col] = new Complex(0, 0);
                }
            }
        }        
        void form_d(ref int[,] in_d, ref double[] z_d, int nd, char td)
        {
            int i, j, g;
            for (int kd = 1; kd <= nd; kd++)
                for (int l = 0; l <= 1; l++)
                {
                    i = in_d[kd, l];
                    if (i == 0) continue;
                    for (int m = 0; m <= 1; m++)
                    {
                        j = in_d[kd, m];
                        if (j == 0) continue;
                        g = (1 - 2 * l) * (1 - 2 * m);
                        switch (td)
                        {
                            case 'R':
                                ViewModel.w[i, j] += g / z_d[kd];
                                break;
                            case 'C':
                                ViewModel.w[i, j] += g * ViewModel.s * z_d[kd];
                                break;
                            case 'L':
                                ViewModel.w[i, j] += g / (ViewModel.s * z_d[kd]);
                                break;
                        }
                    }
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


            ViewModel.kum[kf] = (float)ku.abs;
            ViewModel.kua[kf] = (float)ku.arg * 180.0f / (float)Math.PI;
            ViewModel.rim[kf] = (float)ri.abs;
            ViewModel.ria[kf] = (float)ri.arg * 180.0f / (float)Math.PI;
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

            ri = ViewModel.w[0, ViewModel.lp] - ViewModel.w[0, ViewModel.lm];
            ku = (ViewModel.w[0, ViewModel.kp] - ViewModel.w[0, ViewModel.km]) / ri;

            ViewModel.kum[kf] = (float)ku.abs;
            ViewModel.kua[kf] = (float)ku.arg * 180.0f / (float)Math.PI;
            ViewModel.rim[kf] = (float)ri.abs;
            ViewModel.ria[kf] = (float)ri.arg * 180.0f / (float)Math.PI;
        }

        void form_eu()
        {
            Complex ms = new Complex(0, 0);
            int i, j, g;
            for (int keu = 1; keu <= ViewModel.NEU; keu++)
            {
                ms = ViewModel.z_eu[keu, 0] * (1.0 + ViewModel.s * ViewModel.z_eu[keu, 1]) / (1.0 + ViewModel.s * ViewModel.z_eu[keu, 2]);
                i = ViewModel.n + keu;
                for (int m = 0; m <= 3; m++)
                {
                    j = ViewModel.in_eu[keu, m];
                    if (j == 0) continue;
                    if (m < 2)
                    {
                        g = 1 - 2 * m;
                        ViewModel.w[i, j] += g * ms;
                    }
                    else
                    {
                        g = 5 - 2 * m;
                        ViewModel.w[i, j] -= g;
                        ViewModel.w[j, i] += g;
                    }
                }
            }

            ViewModel.n += ViewModel.NEU;
        }
        void form_ju()
        {
            Complex ys = new Complex(0, 0);
            int i, j, g;
            for (int kju = 1; kju <= ViewModel.NJU; kju++)
            {
                ys = ViewModel.z_ju[kju, 0] * (1 + ViewModel.s * ViewModel.z_ju[kju, 1]) / (1 + ViewModel.s * ViewModel.z_ju[kju, 2]);
                for (int l = 2; l <= 3; l++)
                {
                    i = ViewModel.in_ju[kju, l];
                    if (i == 0) continue;
                    for (int m = 0; m <= 1; m++)
                    {
                        j = ViewModel.in_ju[kju, m];
                        if (j == 0) continue;
                        g = (5 - 2 * l) * (1 - 2 * m);
                        ViewModel.w[i, j] += g * ys;
                    }
                }
            }
        }

        void form_tri()
        {
            int i, j, g;
            for (int ktri = 1; ktri <= ViewModel.NTRI; ktri++)
            {
                i = ViewModel.n + ktri;
                for (int m = 0; m <= 3; m++)
                {
                    j = ViewModel.in_tri[ktri, m];
                    if (j == 0) continue;
                    if (m < 2)
                    {
                        g = 1 - 2 * m;
                        ViewModel.w[i, j] += g * ViewModel.z_tri[ktri];
                        ViewModel.w[j, i] -= g * ViewModel.z_tri[ktri];
                    }
                    else
                    {
                        g = 5 - 2 * m;

                        ViewModel.w[i, j] -= g;
                        ViewModel.w[j, i] += g;
                    }
                }
            }
            ViewModel.n += ViewModel.NTRI;
        }
    }
}
