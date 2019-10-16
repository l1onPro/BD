using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Models
{
    class C : Element
    {
        public C(int curNum) : base("Конденсатор C", "Емкость (Ф)", curNum, 0, 0, 0)
        {
        }
        public C(int curNum, int n_plus, int n_minus, float z) : base("Конденсатор C", "Емкость (Ф)", curNum, n_plus, n_minus, z)
        {
        }
    }
}
