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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Markup;

namespace SystemOfTests
{
    /// <summary>
    /// Логика взаимодействия для RegWin.xaml
    /// </summary>
    public partial class RegWin : Page
    {
        DB UsersDataBase = new DB(); //Экземпялр класса с методами для подключения к БДшке

        public RegWin()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(new EnterWin(""));
        }

        private void RegistrBut_Click(object sender, RoutedEventArgs e)
        {
            //надо сделать добавление в БД
            if (Proverka(login.Text, parol1.Password, parol2.Password) == true)
            {
                DBWrite(login.Text, parol1.Password);
                NavigationService.Navigate(new EnterWin(login.Text));
            }
        }

        bool Proverka(string log, string pas1, string pas2)
        {
            if (log == "" || pas1 == "" || pas2 == "")
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            else if (pas1 != pas2)
            {
                MessageBox.Show("Пароли не совпадают");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void DBWrite(string login, string password)
        {
            
            try
            {
                UsersDataBase.ConnectToDB();
                SqlCommand command = new SqlCommand("addUser", UsersDataBase.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Login", login));
                command.Parameters.Add(new SqlParameter("@Password", password));
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Не удалось зарегистрироваться");
                UsersDataBase.DisconnectDB();
            }
            finally
            {
                MessageBox.Show("Регистрация успешна!");
                UsersDataBase.DisconnectDB();
            }

        }
    }
}
