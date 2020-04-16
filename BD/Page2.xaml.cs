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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private int _noOfErrorsOnScreen = 0;
        Frame frame;
        public Page2(Frame _frame)
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            frame = _frame;
            acceptButton.IsEnabled = _noOfErrorsOnScreen == 0;
        }        
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {            
            if (ViewModel.IsNotNullNeedEl())
            {
                Page3 p3 = new Page3(frame);
                frame.Navigate(p3);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите какое-нибудь значение больше нуля у резистора!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
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
