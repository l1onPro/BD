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
        public MainPage()
        {
            InitializeComponent();
        }

        public void calculate()
        {
            Calculate.Calculate calculate = new Calculate.Calculate();
            calculate.CalculateAlg();
            string str = "";
            for (int i = 0; i < ViewModels.ViewModel.NR + 1; i++)
            {
                for (int j = 0; j < ViewModels.ViewModel.NR + 1; j++)
                {
                    str += ViewModels.ViewModel.a[i, j] + " ";
                }
                str += "\n";
            }
            result.Text = str;
        }
    }
}
