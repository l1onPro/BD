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
        public static int NV { get; set; } = 0;     //Число узлов
        public static int NR { get; set; } = 0;     //Резисторы
        public static int NC { get; set; } = 0;     //Конденсаторы
        public static int NL { get; set; } = 0;     //Индуктивности
        public static int NF { get; set; } = 0;     //Б/П транзистор
        public static int LP { get; set; } = 0;     //У/п транзистор
        public static int LM { get; set; } = 0;     //Опер. усилители
        public static int KP { get; set; } = 0;     //Трансформаторы
        public static int KM { get; set; } = 0;     //Ид. опер. Усилители
        public static int K { get; set; } = 0;      //Ид. трансформаторы

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
    }
}
