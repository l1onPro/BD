using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BD.ViewModels;
using BD.Models;

namespace BD.FilleApp
{
    class File
    {  
        public static void OutToFile(string fileName)
        {
            StreamWriter streamWriter = new StreamWriter(fileName);
            string str = ConvertToStringViewModel();
            streamWriter.WriteLine(str);
           
            for (int i = 0; i < ViewModel.NR; i++)
            {
                str = ViewModel.listR[i].N_plus.ToString() + " " + ViewModel.listR[i].N_minus.ToString() + " " + ViewModel.listR[i].Z.ToString();
                streamWriter.WriteLine(str);
            }
            for (int i = 0; i < ViewModel.NC; i++)
            {
                str = ViewModel.listC[i].N_plus.ToString() + " " + ViewModel.listC[i].N_minus.ToString() + " " + ViewModel.listC[i].Z.ToString();
                streamWriter.WriteLine(str);
            }
            for (int i = 0; i < ViewModel.NL; i++)
            {
                str = ViewModel.listL[i].N_plus.ToString() + " " + ViewModel.listL[i].N_minus.ToString() + " " + ViewModel.listL[i].Z.ToString();
                streamWriter.WriteLine(str);
            }
            for (int i = 1; i <= ViewModel.NEU; i++)
            {
                str = ViewModel.in_eu[i, 0] + " " + ViewModel.in_eu[i, 1] + " " + ViewModel.in_eu[i, 2] + " "
                      + ViewModel.in_eu[i, 3] + " " + ViewModel.z_eu[i, 0] + " " + ViewModel.z_eu[i, 1] + " " + ViewModel.z_eu[i, 2];
                streamWriter.WriteLine(str);
            }

            for (int i = 1; i <= ViewModel.NJU; i++)
            {
                str = ViewModel.in_ju[i, 0] + " " + ViewModel.in_ju[i, 1] + " " + ViewModel.in_ju[i, 2] + " "
                      + ViewModel.in_ju[i, 3] + " " + ViewModel.z_ju[i, 0] + " " + ViewModel.z_ju[i, 1] + " " + ViewModel.z_ju[i, 2];
                streamWriter.WriteLine(str);
            }

            for (int i = 1; i <= ViewModel.NTRI; i++)
            {
                str = ViewModel.in_tri[i, 0] + " " + ViewModel.in_tri[i, 1] + " " + ViewModel.in_tri[i, 2] + " "
                      + ViewModel.in_tri[i, 3] + " " + ViewModel.z_tri[i];
                streamWriter.WriteLine(str);
            }
            streamWriter.Close();
        }
        public static bool InputFromFile(string fileName)
        {
            try
            {
                StreamReader stream = new StreamReader(fileName);
                char[] sep = { ' ' };
                string str = "";
                str = stream.ReadLine();
                string[] s = str.Split(sep, 7);

                bool check = CheckTryParse(s);

                if (check)
                {
                    ViewModel.NV = Int32.Parse(s[0]);
                    ViewModel.NR = Int32.Parse(s[1]);
                    ViewModel.NC = Int32.Parse(s[2]);
                    ViewModel.NL = Int32.Parse(s[3]);
                    ViewModel.NEU = Int32.Parse(s[4]);
                    ViewModel.NJU= Int32.Parse(s[5]);
                    ViewModel.NTRI = Int32.Parse(s[6]);

                    ViewModel.listR = new List<R>();
                    ViewModel.listC= new List<C>();
                    ViewModel.listL = new List<L>();
                }
                else
                {
                    stream.Close();
                    return false;
                }

                for (int i = 0; i < ViewModel.NR; i++)
                {
                    str = stream.ReadLine();
                    s = str.Split(sep, 3);
                    check = CheckTryParse(s);

                    if (check)
                    {
                        R newR = new R(i);
                        newR.N_plus = Int32.Parse(s[0]);
                        newR.N_minus = Int32.Parse(s[1]);
                        newR.Z = Double.Parse(s[2]);
                        ViewModel.listR.Add(newR);
                    }
                    else
                    {
                        stream.Close();
                        return false;
                    }
                }

                for (int i = 0; i < ViewModel.NC; i++)
                {
                    str = stream.ReadLine();
                    s = str.Split(sep, 3);
                    check = CheckTryParse(s);

                    if (check)
                    {
                        C newC = new C(i);
                        newC.N_plus = Int32.Parse(s[0]);
                        newC.N_minus = Int32.Parse(s[1]);
                        newC.Z = Double.Parse(s[2]);
                        ViewModel.listC.Add(newC);
                    }
                    else
                    {
                        stream.Close();
                        return false;
                    }
                }

                for (int i = 0; i < ViewModel.NL; i++)
                {
                    str = stream.ReadLine();
                    s = str.Split(sep, 3);
                    check = CheckTryParse(s);

                    if (check)
                    {
                        L newL = new L(i);
                        newL.N_plus = Int32.Parse(s[0]);
                        newL.N_minus = Int32.Parse(s[1]);
                        newL.Z = Double.Parse(s[2]);
                        ViewModel.listL.Add(newL);
                    }
                    else
                    {
                        stream.Close();
                        return false;
                    }
                }
                for (int i = 1; i <= ViewModel.NEU; i++)
                {
                    str = stream.ReadLine();
                    s = str.Split(sep, 7);
                    ViewModel.in_eu[i, 0] = Int32.Parse(s[0]);
                    ViewModel.in_eu[i, 1] = Int32.Parse(s[1]);
                    ViewModel.in_eu[i, 2] = Int32.Parse(s[2]);
                    ViewModel.in_eu[i, 3] = Int32.Parse(s[3]);
                    ViewModel.z_eu[i, 0] = Single.Parse(s[4]);
                    ViewModel.z_eu[i, 1] = Single.Parse(s[5]);
                    ViewModel.z_eu[i, 2] = Single.Parse(s[6]);
                }

                for (int i = 1; i <= ViewModel.NJU; i++)
                {
                    str = stream.ReadLine();
                    s = str.Split(sep, 7);
                    ViewModel.in_ju[i, 0] = Int32.Parse(s[0]);
                    ViewModel.in_ju[i, 1] = Int32.Parse(s[1]);
                    ViewModel.in_ju[i, 2] = Int32.Parse(s[2]);
                    ViewModel.in_ju[i, 3] = Int32.Parse(s[3]);
                    ViewModel.z_ju[i, 0] = Single.Parse(s[4]);
                    ViewModel.z_ju[i, 1] = Single.Parse(s[5]);
                    ViewModel.z_ju[i, 2] = Single.Parse(s[6]);
                }

                for (int i = 1; i <= ViewModel.NTRI; i++)
                {
                    str = stream.ReadLine();
                    s = str.Split(sep, 5);
                    ViewModel.in_tri[i, 0] = Int32.Parse(s[0]);
                    ViewModel.in_tri[i, 1] = Int32.Parse(s[1]);
                    ViewModel.in_tri[i, 2] = Int32.Parse(s[2]);
                    ViewModel.in_tri[i, 3] = Int32.Parse(s[3]);
                    ViewModel.z_tri[i] = Single.Parse(s[4]);
                }
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }  
        }

        private static string ConvertToStringViewModel()
        {
            return ViewModel.NV.ToString() + " "
               + ViewModel.NR.ToString() + " "
               + ViewModel.NC.ToString() + " "
               + ViewModel.NL.ToString() + " "
               + ViewModel.NEU.ToString() + " "
               + ViewModel.NJU.ToString() + " "
               + ViewModel.NTRI.ToString();
            /*+ ViewModel.N_BPT.ToString() + "/n"
            + ViewModel.N_UPT.ToString() + "/n"
            + ViewModel.NOA.ToString() + "/n"
            + ViewModel.NT.ToString() + "/n"
            + ViewModel.NIOA.ToString() + "/n"
            + ViewModel.NTR.ToString() + "/n";*/           
        }
        private static bool CheckTryParse(string[] s)
        {
            foreach (string item in s)
            {
                double i;
                bool good = Double.TryParse(item, out i);
                if (!good) return false;
            }
            return true;
        }
    }
}
