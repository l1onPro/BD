using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Models
{
    class L : Element
    {
        public L(int curNum) : base("Катушка L", "Индуктивность (Гн)", curNum, 0, 0, 0.0)
        {
        }
        public L(int curNum, int n_plus, int n_minus, float z) : base("Катушка L", "Индуктивность (Гн)", curNum, n_plus, n_minus, z)
        {
        }
    }
}
