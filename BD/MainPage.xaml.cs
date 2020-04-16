using BD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BD
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Frame _frame;
        public MainPage(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        public void calculate()
        {
            Calculate.Calculate calculate = new Calculate.Calculate();
            calculate.CalculateAlg();
           /* Page10 p10 = new Page10();
            _frame.Navigate(p10);*/

            //Вывод результатов моделирования
            string str = "";
            str = "Результаты моделирования ";
            result.AppendText(str + "\r\n");
            if ((Nodes.lp == 1) && (Nodes.lm == 0) && (Nodes.kp == 2) && (Nodes.km == 0))
            {
                str = "    f кГц \t kum \t kua \t rim \t ria \t rom \t roa";
                result.AppendText(str + "\r\n");
                for (int kf = 0; kf <= ViewModel.F.Count; kf++)
                {
                    str = String.Format("{0,12:F2}{1,12:F2}{2,12:F2}" +
                        "{3,12:F2}{4,12:F2}{5,12:F2}{6,12:F2}",
                          ViewModel.f[kf], ViewModel.kum[kf], ViewModel.kua[kf], ViewModel.rim[kf],
                          ViewModel.ria[kf], ViewModel.rom[kf], ViewModel.roa[kf]);
                    result.AppendText(str + "\r\n");
                }
            }
            else
            {
                result.Text = "";
                str = "    f кГц \t kum \t kua \t rim \t ria";
                result.AppendText(str + "\r\n");
                for (int kf = 1; kf <= ViewModel.F.Count; kf++)
                {
                    str = String.Format("{0,12:F2}{1,12:F2}{2,12:F2}" +
                        "{3,12:F2}{4,12:F2}",
                            ViewModel.f[kf], ViewModel.kum[kf], ViewModel.kua[kf], ViewModel.rim[kf], ViewModel.ria[kf]);
                    result.AppendText(str + "\r\n");
                }
            }

            /*string str = "";
            for (int i = 0; i < ViewModels.ViewModel.NR + 1; i++)
            {
                for (int j = 0; j < ViewModels.ViewModel.NR + 1; j++)
                {
                    str += ViewModels.ViewModel.a[i, j] + " ";
                }
                str += "\n";
            }*/
            
        }
    }
}
