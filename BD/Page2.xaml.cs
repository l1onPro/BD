﻿using System;
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
        Frame frame;
        public Page2(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Page3 p3 = new Page3(frame);
            frame.Navigate(p3);
        }
    }
}
