using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
namespace BD
{
    /// <summary>
    /// Логика взаимодействия для Page9.xaml
    /// </summary>
    public partial class Page9 : Page
    {
        Frame frame;
        List<string> listURL;
        public Page9(Frame frame)
        {
            InitializeComponent();

            InitListURL();
            this.frame = frame;
        }

        public void InitListURL()
        {
            listURL = new List<string>();
            listURL.Add("http://localhost/MF/beg.html");
            listURL.Add("http://127.0.0.1/MF/Int3d.htm");
            listURL.Add("http://127.0.0.1/MF/ParamComp.html");
            listURL.Add("http://yandex.ru");
            listURL.Add("http://mail.ru");

            cmbIDC.ItemsSource = listURL;
            cmbIDC.SelectedIndex = 0;
        }

        private void IDC_INP_Click(object sender, RoutedEventArgs e)
        {
            string str = cmbIDC.Text;
            explorer.Navigate(str);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (explorer.CanGoBack)
                explorer.GoBack();
            prgsBar.Value = 0;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (explorer.CanGoForward)
                explorer.GoForward();
            prgsBar.Value = 0;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            explorer.Refresh();
            prgsBar.Value = 0;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack)
                frame.GoBack();
        }

        private void explorer_Navigated(object sender, NavigationEventArgs e)
        {
            prgsBar.Value = 0;
        }

        private void explorer_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            prgsBar.Minimum = 0;
            prgsBar.Maximum = 100;
            prgsBar.Value = 0;
        }

        private void explorer_LoadCompleted(object sender, NavigationEventArgs e)
        {
            prgsBar.Value = 100;            
        }
    }
}
