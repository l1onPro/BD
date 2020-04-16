using BD.Models;
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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private int _noOfErrorsOnScreen = 0;

        List<R> listR = new List<R>();
        List<C> listC = new List<C>();
        List<L> listL = new List<L>();

        R newR;
        C newC;
        L newL;

        int numCurEl = -1;
        int curNum = -1;
        int maxNum = -1;
        
        Frame frame;
        public Page3(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;

            SetNewElement();
        }
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewEl();
            SetNewElement();
        }
        private void AddNewEl()
        {
            switch (numCurEl)
            {
                case 0:
                    listR.Add(newR);
                    break;
                case 1:
                    listC.Add(newC);
                    break;
                case 2:
                    listL.Add(newL);
                    break;
                default:
                    throw new Exception();
            }
            curNum++;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
            acceptButton.IsEnabled = _noOfErrorsOnScreen == 0;
        }
        private void NexPage()
        {
            ViewModel.listR = listR;
            ViewModel.listC = listC;
            ViewModel.listL = listL;

            SetParForBackButton();

            EU p4 = new EU(frame);
            frame.Navigate(p4);
        }
        private void SetParForBackButton()
        {
            //Если вернуться через кнопку назад
            numCurEl = -1;
            curNum = -1;
            maxNum = -1;

            SetNewElement();
            /* ------------------------------ */
        }
        private void SetNewElement()
        {
            if (curNum >= maxNum)
                FindNewEl();

            switch (numCurEl)
            {
                case 0:
                    newR = new R(curNum);
                    DataContext = newR;
                    break;
                case 1:
                    newC = new C(curNum);
                    DataContext = newC;
                    break;
                case 2:
                    newL = new L(curNum);
                    DataContext = newL;
                    break;
                default:
                    break;
            }
        }
        private void FindNewEl()
        {
            if (numCurEl == -1)
            {
                if (ViewModel.NR > 0)
                {
                    curNum = 0;
                    maxNum = ViewModel.NR;
                    numCurEl++;
                    return;
                }
                else
                    numCurEl++;
            }
            if (numCurEl == 0)
            {
                if (ViewModel.NC > 0)
                {
                    curNum = 0;
                    maxNum = ViewModel.NC;
                    numCurEl++;
                    return;
                }
                else
                    numCurEl++;
            }
            if (numCurEl == 1)
            {                
                if (ViewModel.NL > 0)
                {
                    curNum = 0;
                    maxNum = ViewModel.NL;
                    numCurEl++;                    
                    return;
                }
                else
                    numCurEl++;
            }
            if (numCurEl > 1)
                NexPage();
        }       
    }
}
