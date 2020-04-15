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
    /// Логика взаимодействия для Page10.xaml
    /// </summary>
    public partial class Page10 : Page
    {
        public Page10()
        {
            InitializeComponent();
            txt1.Text = Convert.ToString(ViewModel.F[0]);
            txt2.Text = Convert.ToString(ViewModel.kum[1]);
            txt3.Text = Convert.ToString(ViewModel.kua[1]);
            txt4.Text = Convert.ToString(ViewModel.rim[1]);
            txt5.Text = Convert.ToString(ViewModel.ria[1]);
        }

        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
