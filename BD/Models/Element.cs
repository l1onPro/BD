﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Models
{
    class Element
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public int CurNum { get; set; }
        public int[] in_el { get; set; } = new int[2];
        public int N_plus
        {
            get
            {
                return in_el[0];
            }
            set
            {
                in_el[0] = value;
            }
        }
        public int N_minus
        {
            get
            {
                return in_el[1];
            }
            set
            {
                in_el[1] = value;
            }
        }
        public double Z { get; set; } = 0.0;

        public override string ToString()
        {
            return "Name: " + Name +
                   "Unit: " + Unit +
                   "CurNum: " + CurNum +
                   "N_plus: " + N_plus +
                   "N_minus: " + N_minus +
                   "Z: " + Z;
        }

        public Element(string name, string unit, int curNum, int n_plus, int n_minus, double z)
        {
            Name = name;
            Unit = unit;
            CurNum = curNum;
            N_plus = n_plus;
            N_minus = n_minus;            
            Z = z;
        }

        public override bool Equals(object obj)
        {
            return obj is Element element &&
                   Name == element.Name &&
                   Unit == element.Unit &&
                   CurNum == element.CurNum &&
                   N_plus == element.N_plus &&
                   N_minus == element.N_minus;
        }

        public override int GetHashCode()
        {
            var hashCode = 259247372;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Unit);
            hashCode = hashCode * -1521134295 + CurNum.GetHashCode();
            hashCode = hashCode * -1521134295 + N_plus.GetHashCode();
            hashCode = hashCode * -1521134295 + N_minus.GetHashCode();
            return hashCode;
        }
    }
}
