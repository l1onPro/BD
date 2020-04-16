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
    /// Логика взаимодействия для EU.xaml
    /// </summary>   
    public partial class EU : Page
    {
        Frame frame;
        public EU(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox2.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(textBox1.Text);            
            ViewModel.in_eu[i, 0] = Int32.Parse(textBox2.Text);
            ViewModel.in_eu[i, 1] = Int32.Parse(textBox3.Text);
            ViewModel.in_eu[i, 2] = Int32.Parse(textBox6.Text);
            ViewModel.in_eu[i, 3] = Int32.Parse(textBox5.Text);
            ViewModel.z_eu[i, 0] = Int32.Parse(textBox4.Text);
            ViewModel.z_eu[i, 1] = Int32.Parse(textBox8.Text);
            ViewModel.z_eu[i, 2] = Int32.Parse(textBox7.Text);
            i++;
            textBox1.Text = i.ToString();
            if (i <= ViewModel.NEU)
            {
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox2.Focus();
            }
            else
            {                
                if (ViewModel.NJU > 0)
                {
                    JU p4 = new JU(frame);
                    frame.Navigate(p4);
                }
                else if (ViewModel.NTRI > 0)
                {
                    TRI p4 = new TRI(frame);
                    frame.Navigate(p4);
                }
                else if (ViewModel.NOU > 0)
                {
                    OU p4 = new OU(frame);
                    frame.Navigate(p4);
                }
                else
                {
                    Page4 p4 = new Page4(frame);
                    frame.Navigate(p4);
                }
            }
        }
    }
}
