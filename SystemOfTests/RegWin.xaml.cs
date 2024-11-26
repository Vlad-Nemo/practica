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

            if (Proverka(login.Text, parol1.Password, parol2.Password) == true && DBWrite(login.Text, parol1.Password) == 0) //Запись данных в БД c проверкой занятости имени 
            {
                MessageBox.Show("Регистрация успешна!");
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
        private int DBWrite(string login, string password)
        {
            int DBanswer; //Ответ из БД где 1 - имя занято, 0 - свободно

            try
            {
                UsersDataBase.ConnectToDB();
                SqlCommand command = new SqlCommand("addUser", UsersDataBase.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Login", login));
                command.Parameters.Add(new SqlParameter("@Password", password));
                var returnParameter = command.Parameters.Add("@thisUserNameIsBusy", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();
                DBanswer = (int)returnParameter.Value;
                if (DBanswer == 1)
                {
                    throw new Exception("Имя занято");
                }
                UsersDataBase.DisconnectDB();
                return DBanswer;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Не удалось зарегистрироваться по причине: {e.Message}");
                UsersDataBase.DisconnectDB();
                return 1;
            }
        }
    }
}
