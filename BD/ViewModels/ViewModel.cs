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
        public static int NF { get; set; } = 0;
        /// <summary>
        /// У/п транзистор
        /// </summary>
        public static int LP { get; set; } = 0;
        /// <summary>
        /// Кол-во опер. усилителей
        /// </summary>
        public static int LM { get; set; } = 0;
        /// <summary>
        /// Кол-во трансформаторов
        /// </summary>
        public static int KP { get; set; } = 0;
        /// <summary>
        /// Кол-во ид. опер. исилителей
        /// </summary>
        public static int KM { get; set; } = 0;
        /// <summary>
        /// Кол-во ид. трансформаторов
        /// </summary>
        public static int K { get; set; } = 0;   
        public static List<R> listR { get; set; }
        public static List<C> listC { get; set; }
        public static List<L> listL { get; set; }
        public ViewModel()
        {
           
        }

        public static bool IsNotNullNeedEl()
        {
            if (NR > 0 || NC > 0 || NL > 0)
                return true;

            return false;
        }
        public static bool IsNotNull()
        {
            if (NV > 0 || NR > 0 || NC > 0 || NL > 0 || NF > 0 || LP > 0 || LM > 0 || KP > 0 || KM > 0 || K > 0)
                return true;

            return false;
        }
        public static bool IsNotNullListsEl()
        {
            if (NR > 0 && listR == null) return false;
            if (NC > 0 && listC == null) return false;
            if (NL > 0 && listL == null) return false;

            return true;
        }
    }
}
