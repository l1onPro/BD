using BD.FilleApp;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainPage mainPage = new MainPage(mainWindowFrame);
            mainWindowFrame.Navigate(mainPage);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool exit = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
            if (exit) e.Cancel = false;
            else e.Cancel = true;            
        }

        /// <summary>
        /// Close program from MenuItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MIExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MIAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Приложение разработано на WPF студентами группы 6302.", "Справка", MessageBoxButton.OK);
        }

        private void MIInpKeyboard_Click(object sender, RoutedEventArgs e)
        {
            Page2 p2 = new Page2(mainWindowFrame);
            mainWindowFrame.Navigate(p2);
        }

        private void MITypeFreqResponse_Click(object sender, RoutedEventArgs e)
        {
            Page5 p5 = new Page5(mainWindowFrame);
            mainWindowFrame.Navigate(p5);
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(mainWindowFrame);
            mainWindowFrame.Navigate(mainPage);
        }

        private void btnDescript_Click(object sender, RoutedEventArgs e)
        {
            Page1 p1 = new Page1(mainWindowFrame);
            mainWindowFrame.Navigate(p1);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Page6 p6 = new Page6(mainWindowFrame);
            mainWindowFrame.Navigate(p6);
        }

        private void MIOpenFile_Click(object sender, RoutedEventArgs e)
        {
            Page7 p7 = new Page7(mainWindowFrame);
            mainWindowFrame.Navigate(p7);
        }

        private void MIInpOutNodes_Click(object sender, RoutedEventArgs e)
        {
            Page8 p8 = new Page8(mainWindowFrame);
            mainWindowFrame.Navigate(p8);
        }

        private void MIOwnBrow_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.typeInternet = Models.TypeInternet.Own;
        }

        private void MISysBrow_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.typeInternet = Models.TypeInternet.System;
        }

        private void MICalculate_Click(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(mainWindowFrame);
            mainWindowFrame.Navigate(mainPage);
            mainPage.calculate();
        }

        private void MIInternet_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.typeInternet == Models.TypeInternet.Own)
            {
                Page9 p9 = new Page9(mainWindowFrame);
                mainWindowFrame.Navigate(p9);
            }
            else
            {
                System.Diagnostics.Process.Start("http://127.0.0.1/MF/Int3d.htm");
            }
        }
    }
}
