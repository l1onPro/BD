using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Models
{
    class R : Element
    {
        public R(int curNum) : base("Резистор R", "Сопротивление (КОм)", curNum, 0, 0, 0)
        {
        }
        public R(int curNum, int n_plus, int n_minus, float z) : base("Резистор R", "Сопротивление (КОм)", curNum, n_plus, n_minus, z)
        {
        }
    }
}
