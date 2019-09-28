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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        Frame frame;
        public Page3(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Page p4 = new Page4(frame);
            frame.Navigate(p4);
        }
    }
}
