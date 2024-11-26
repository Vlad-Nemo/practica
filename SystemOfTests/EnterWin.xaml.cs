using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
        DB UsersDataBase = new DB(); //Экземпялр класса с методами для подключения к БДшке

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
                MessageBox.Show("Успешный вход!");
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
            else if (pas1 != "123")
            {
                MessageBox.Show("Пароли не совпадают");
                return false;
            }
            else if (DBCheck(log, pas1) == false) //Проверка на наличие пользорвателя в БДшке
            {
                MessageBox.Show("Пользователь с таким именем не обнаружен");
                return false;
            }
            else
            {
                return true;
            }
        }
        private Boolean DBCheck(string login, string password) //Проверка наличия пары логин-пароль в базе
        {

            bool result; //Переменная-индикатор успешного входа
            DataTable foundUsers = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                UsersDataBase.ConnectToDB();
                SqlCommand command = new SqlCommand("findUser", UsersDataBase.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Login", login));
                command.Parameters.Add(new SqlParameter("@Password", password));

                command.ExecuteNonQuery();

                adapter.SelectCommand = command;
                adapter.Fill(foundUsers);
            }
            catch
            {
                MessageBox.Show("Ошибка входа");
                UsersDataBase.DisconnectDB();
            }
            finally
            {
                if (foundUsers.Rows.Count == 1)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                UsersDataBase.DisconnectDB();
            }
            return result;
        }
    }
}
