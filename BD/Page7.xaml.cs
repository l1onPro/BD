using BD.FilleApp;
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
    /// Логика взаимодействия для Page7.xaml
    /// </summary>
    public partial class Page7 : Page
    {
        Frame frame;
        public Page7(Frame _frame)
        {
            InitializeComponent(); 
            frame = _frame;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            bool good = File.InputFromFile(txtNameFile.Text + ".txt");
            if (!good) MessageBox.Show("Не удалось открыть с файла", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                Page5 p5 = new Page5(frame);
                frame.Navigate(p5);
            }
        }
    }
}
