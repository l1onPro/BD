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
    /// Логика взаимодействия для Page8.xaml
    /// </summary>
    public partial class Page8 : Page
    {
        private int _noOfErrorsOnScreen = 0;

        Frame frame;
        public Page8(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            DataContext = new Nodes();
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
            acceptButton.IsEnabled = _noOfErrorsOnScreen == 0;
        }
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
