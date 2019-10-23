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
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        private int _noOfErrorsOnScreen = 0;
        Frame frame;

        List<string> listEl;      
        public Page6(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
            acceptButton.IsEnabled = _noOfErrorsOnScreen == 0;

            CheckGoodEdit();

            listEl = new List<string>();
            listEl.Add("Резисторы");
            listEl.Add("Конденсаторы");
            listEl.Add("Индуктивности");           

            listBoxEl.Items.Clear();
            setListBox();
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
        private void setListBox()
        {
            if (ViewModel.NR > 0) listBoxEl.Items.Add(listEl[0]);
            if (ViewModel.NC > 0) listBoxEl.Items.Add(listEl[1]);
            if (ViewModel.NL > 0) listBoxEl.Items.Add(listEl[2]);
        }

        private void listBoxEl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxEl.SelectedItem.ToString() == listEl[0]) setComboBox(ViewModel.NR);
            if (listBoxEl.SelectedItem.ToString() == listEl[1]) setComboBox(ViewModel.NC);
            if (listBoxEl.SelectedItem.ToString() == listEl[2]) setComboBox(ViewModel.NL);
        }
        private void setComboBox(int maxValue)
        {
            m_num.Items.Clear();
            for (int i = 0; i < maxValue; i++)
            {
                m_num.Items.Add(i);
            }
            m_num.SelectedIndex = 0;
        }

        private void m_num_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int curNumEl = m_num.SelectedIndex;
            if (curNumEl == -1) SetStandartText();          
            else
            {
                if (listBoxEl.SelectedItem.ToString() == listEl[0])
                {
                    this.DataContext = ViewModel.listR[curNumEl];
                }
                if (listBoxEl.SelectedItem.ToString() == listEl[1])
                {
                    this.DataContext = ViewModel.listC[curNumEl];
                }
                if (listBoxEl.SelectedItem.ToString() == listEl[2])
                {
                    this.DataContext = ViewModel.listL[curNumEl];
                }
            }           
        }

        private void SetStandartText()
        {
            m_nm1.Text = "";
            m_nm2.Text = "";
            m_np1.Text = "";
            m_np2.Text = "";
            m_z1.Text = "";
            m_z2.Text = "";
            m_z3.Text = "";
            m_z4.Text = "";
            m_z5.Text = "";
            m_z6.Text = "";
        }
        private void SetIsNotEnableEdit()
        {
            listBoxEl.IsEnabled = false;
            m_num.IsEnabled = false;

            m_nm1.IsEnabled = false;
            m_nm2.IsEnabled = false;
            m_np1.IsEnabled = false;
            m_np2.IsEnabled = false;
            m_z1.IsEnabled =  false;
            m_z2.IsEnabled =  false;
            m_z3.IsEnabled =  false;
            m_z4.IsEnabled =  false;
            m_z5.IsEnabled =  false;
            m_z6.IsEnabled =  false;
        }       
        private void CheckGoodEdit()
        {
            if (!ViewModel.IsNotNullNeedEl() || !ViewModel.IsNotNullListsEl())
            {
                SetIsNotEnableEdit();
                MessageBox.Show("Пожалуйста, введите данные для изменения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }
    }    
}
