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

namespace SystemOfTests
{
    /// <summary>
    /// Логика взаимодействия для TestMainMenu.xaml
    /// </summary>
    public partial class TestMainMenu : Page
    {
        public TestMainMenu()
        {
            InitializeComponent();
        }

        private void ExitBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegWin());
        }

        private void Test1But_Click(object sender, RoutedEventArgs e)
        {
            ViewModel view = new ViewModel(test1.Name);
            NavigationService.Navigate(new Tests(test1.Name));
        }

        private void Test2But_Click(object sender, RoutedEventArgs e)
        {
            ViewModel view = new ViewModel(test2.Name);
            NavigationService.Navigate(new Tests(test2.Name));
        }

        private void Test3But_Click(object sender, RoutedEventArgs e)
        {
            ViewModel view = new ViewModel(test3.Name);
            NavigationService.Navigate(new Tests(test3.Name));
        }
    }
}
