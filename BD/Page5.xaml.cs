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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        Frame frame;
        private int _noOfErrorsOnScreen = 0;
        public Page5(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
            CheckRadioBtn();
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
            acceptButton.IsEnabled = _noOfErrorsOnScreen == 0;
        }
        private void CheckRadioBtn()
        {
            if (ViewModel.TypeLaw.GetTypeLaw() == new Single_frequency_point().GetTypeLaw())
            {
                rd1.IsChecked = true;
                rd2.IsChecked = false;
                rd3.IsChecked = false;
            }
            if (ViewModel.TypeLaw.GetTypeLaw() == new Linear_law().GetTypeLaw())
            {
                rd1.IsChecked = false;
                rd2.IsChecked = true;
                rd3.IsChecked = false;               
            }
            if (ViewModel.TypeLaw.GetTypeLaw() == new Logarithmic_law().GetTypeLaw())
            {
                rd1.IsChecked = false;
                rd2.IsChecked = false;
                rd3.IsChecked = true;                
            }
            UpdateWindow();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.TypeLaw.SetListF();
        }

        private void rd1_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.TypeLaw = new Single_frequency_point();
            IDC1.Text = "Значение частоты (кГЦ)";
            IDC2.Text = "";
            IDC3.Text = "";

            txtNum1.IsEnabled = true;
            txtNum2.IsEnabled = false;
            txtNum3.IsEnabled = false;

            UpdateWindow();
        }

        private void rd2_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.TypeLaw = new Linear_law();
            IDC1.Text = "Минимальная частота Fmin(кГц)";
            IDC2.Text = "Максимальная частота(кГц)";
            IDC3.Text = "Шаг изменения dF(кГц)";

            txtNum1.IsEnabled = true;
            txtNum2.IsEnabled = true;
            txtNum3.IsEnabled = true;

            UpdateWindow();
        }

        private void rd3_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.TypeLaw = new Logarithmic_law();
            IDC1.Text = "Минимальная частота Fmin(кГц)";
            IDC2.Text = "Максимальная частота(кГц)";
            IDC3.Text = "Отношение соседних частот К";

            txtNum1.IsEnabled = true;
            txtNum2.IsEnabled = true;
            txtNum3.IsEnabled = true;

            UpdateWindow();
        }        
        private void UpdateWindow()
        {
            DataContext = ViewModel.TypeLaw;
        }
    }
}
