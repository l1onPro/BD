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

        public static Frequency TypeLaw { get; set; } = new Single_frequency_point();
        public static List<float> F;
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

            F = new List<float>();
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
