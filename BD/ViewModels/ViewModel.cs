using BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.ViewModels
{
    class ViewModel
    {
        public static int N { get; set; } = 0;
        /// <summary>
        /// Число узлов
        /// </summary>
        public static int NV { get; set; } = 0;
        /// <summary>
        /// Кол-во резисторов
        /// </summary>
        public static int NR { get; set; } = 0;
        /// <summary>
        /// Кол-во  конденсаторов
        /// </summary>
        public static int NC { get; set; } = 0;
        /// <summary>
        /// Кол-во индуктивностей
        /// </summary>
        public static int NL { get; set; } = 0;
        /// <summary>
        /// Кол-во Б/П транзисторов
        /// </summary>
        public static int N_BPT { get; set; } = 0;
        /// <summary>
        /// У/п транзистор
        /// </summary>
        public static int N_UPT { get; set; } = 0;
        /// <summary>
        /// Кол-во опер. усилителей
        /// </summary>
        public static int NOA { get; set; } = 0;
        /// <summary>
        /// Кол-во трансформаторов
        /// </summary>
        public static int NT { get; set; } = 0;
        /// <summary>
        /// Кол-во ид. опер. усилителей
        /// </summary>
        public static int NIOA { get; set; } = 0;
        /// <summary>
        /// Кол-во ид. трансформаторов
        /// </summary>
        public static int NTR { get; set; } = 0; 

        public static List<R> listR { get; set; }
        public static List<C> listC { get; set; }
        public static List<L> listL { get; set; }
        
        public static List<double> F;

        public static int M = 100, MR = 50, MF = 20;
        public static int n = 0, lp, lm, kp, km;
        public static int[,] in_r = new int[MR + 1, 2];
        public static int[,] in_c = new int[MR + 1, 2];
        public static int[,] in_l = new int[MR + 1, 2];

        public static double[] z_r = new double[MR + 1];
        public static double[] z_c = new double[MR + 1];
        public static double[] z_l = new double[MR + 1];
        public static double[,] a = new double[M + 1, M + 1];
        public static double[,] b = new double[M + 1, M + 1];
        public static double om;
        public static Complex[,] w = new Complex[M + 1, M + 1];
        public static double[] kum = new double[MF + 1];
        public static double[] kua = new double[MF + 1];
        public static double[] rim = new double[MF + 1];
        public static double[] ria = new double[MF + 1];
        public static double[] rom = new double[MF + 1];
        public static double[] roa = new double[MF + 1];
        public static double[] f = new double[MF + 1];
        public static void vGovno()
        {
            int j = 1;
            for (int i = 0; i < listR.Count; i++)
            {
                in_r[j, 0] = listR[i].N_plus;
                in_r[j, 1] = listR[i].N_minus;
                z_r[j] = listR[i].Z;
                j++;
            }
            j = 1;
            for (int i = 0; i < listC.Count; i++)
            {
                in_c[j, 0] = listC[i].N_plus;
                in_c[j, 1] = listC[i].N_minus;
                z_c[j] = listC[i].Z;
                j++;
            }
            j = 1;
            for (int i = 0; i < listL.Count; i++)
            {
                in_l[j, 0] = listL[i].N_plus;
                in_l[j, 1] = listL[i].N_minus;
                z_l[j] = listL[i].Z;
                j++;
            }
            n = NV;
            j = 1;
            for (int i = 0; i < F.Count; i++)
            {
                f[j] = F[i];
                j++;
            }
            lp = Nodes.lp + 1;
            lm = Nodes.lm + 1;
            kp = Nodes.kp + 1;
            km = Nodes.km + 1;
        }
        public static TypeInternet typeInternet { get; set; } = TypeInternet.Own;
        public ViewModel()
        {
           
        }
        public ViewModel(int num)
        {
            NV = 0;
            NR = 0;
            NC = 0;
            NL = 0;

            listR = new List<R>();
            listC = new List<C>();
            listL = new List<L>();

            F = new List<double>();
        }
        public static bool IsNotNullNeedEl()
        {
            if (NR > 0 || NC > 0 || NL > 0)
                return true;

            return false;
        }
        public static bool IsNotNull()
        {
            if (NV > 0 || NR > 0 || NC > 0 || NL > 0 || N_BPT > 0 || N_UPT > 0 || NOA > 0 || NT > 0 || NIOA > 0 || NTR > 0)
                return true;

            return false;
        }
        public static bool IsNotNullListF()
        {
            if (F == null) return false;

            return true;
        }
        public static bool IsNotNullListsEl()
        {
            if (NR >= 0 && listR == null) return false;
            if (NC >= 0 && listC == null) return false;
            if (NL >= 0 && listL == null) return false;
            /*if (N_BPT > 0 && listBPT == null) return false;
            if (N_UPT > 0 && listUPT == null) return false;
            if (NOA > 0 && listOA == null) return false;
            if (NT > 0 && listT == null) return false;
            if (NIOA > 0 && listIOA == null) return false;
            if (NTR > 0 && listTR == null) return false;*/

            return true;
        }

        public override string ToString()
        {
            return NV.ToString()
                + NR.ToString()
                + NC.ToString()
                + NL.ToString()
                + N_BPT.ToString()
                + N_UPT.ToString()
                + NOA.ToString()
                + NT.ToString()
                + NIOA.ToString()
                + NTR.ToString();
        }
    }
}
