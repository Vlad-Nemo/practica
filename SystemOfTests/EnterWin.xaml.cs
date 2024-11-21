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

namespace SystemOfTests
{
    /// <summary>
    /// Логика взаимодействия для EnterWin.xaml
    /// </summary>
    public partial class EnterWin : Page
    {
        public EnterWin(string enterLogin)
        {
            InitializeComponent();
            login.Text = enterLogin;
        }

        private void RegBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegWin());
        }

        private void EnterBut_Click(object sender, RoutedEventArgs e)
        {
            if (Proverka(login.Text, parol1.Password) == true)
            {
                NavigationService.Navigate(new TestMainMenu());
            }
        }
        bool Proverka(string log, string pas1)
        {
            if (log == "" || pas1 == "")
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            else if (pas1 != "123")//проверка с БД
            {
                MessageBox.Show("Пароли не совпадают");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
