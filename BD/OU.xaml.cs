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
    /// Логика взаимодействия для OU.xaml
    /// </summary>
    public partial class OU : Page
    {        
        Frame frame;
        public OU(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            Ri.Text = "0";
            R0.Text = "0";
            u.Text = "0";
            ft.Text = "0";
            textBox2.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(textBox1.Text);
            ViewModel.in_ou[i, 1] = Int32.Parse(textBox2.Text);
            ViewModel.in_ou[i, 2] = Int32.Parse(textBox3.Text);
            ViewModel.in_ou[i, 3] = Int32.Parse(textBox4.Text);
            ViewModel.in_ou[i, 4] = Int32.Parse(textBox5.Text);
            ViewModel.z_ou[i, 0] = Int32.Parse(Ri.Text);
            ViewModel.z_ou[i, 1] = (float)Double.Parse(R0.Text);
            ViewModel.z_ou[i, 2] = Int32.Parse(u.Text);
            ViewModel.z_ou[i, 3] = Int32.Parse(ft.Text);
            i++;
            textBox1.Text = i.ToString();
            if (i <= ViewModel.NEU)
            {
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "0";
                Ri.Text = "0";
                R0.Text = "0";
                u.Text = "0";
                ft.Text = "0";
                textBox2.Focus();
            }
            else
            {
                Page4 p4 = new Page4(frame);
                frame.Navigate(p4);
            }
        }
    }
}
