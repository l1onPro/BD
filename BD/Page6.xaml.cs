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
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        private int _noOfErrorsOnScreen = 0;
        Frame frame;
        public Page6(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
            acceptButton.IsEnabled = _noOfErrorsOnScreen == 0;
        }
        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
            acceptButton.IsEnabled = _noOfErrorsOnScreen == 0;
        }
    }    
}
