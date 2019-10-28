using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.ViewModels
{
    class Nodes
    {
        public static int lp { get; set; } = 0;
        public static int lm { get; set; } = 0;
        public static int kp { get; set; } = 0;
        public static int km { get; set; } = 0;
        public Nodes(bool Default = false)
        {
            if (Default)
            {
                lp = lm = kp = km = 0;
            }
        }
    }
}
