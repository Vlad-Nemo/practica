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
        string connectionString;
        SqlDataAdapter adapter;

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
            //connectionString = ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString;
            connectionString = @"Data Source = LAZARPC; Initial Catalog = AppDB; Integrated Security = True";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);

                adapter.InsertCommand = new SqlCommand("dbo.addUser", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Login", SqlDbType.NVarChar, 50, login));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50, password));
                connection.Open();

            }
            catch
            {

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }
    }
}
