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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Frame frame;
        public Page1(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page2 p2 = new Page2(frame);
            frame.Navigate(p2);
        }
    }
}
