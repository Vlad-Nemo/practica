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
    /// Логика взаимодействия для LaderBoard.xaml
    /// </summary>
    public partial class LaderBoard : Page
    {
        DB ScoreTestTable = new DB(); //Экземпялр класса с методами для подключения к БДшке
        public LaderBoard(string ocenka, string Testname)
        {
            InitializeComponent();
            FillScoreTable(Testname);
            ocenkaUser.Text = $"{ocenka}/10";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestMainMenu());
        }

        private void ShutdownBut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void FillScoreTable(string TestName)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                ScoreTestTable.ConnectToDB();
                SqlCommand command = new SqlCommand("SelectScores", ScoreTestTable.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Testname", TestName));

                command.ExecuteNonQuery();

                SqlDataReader read = command.ExecuteReader(); //Считываем и извлекаем данные
                while (read.Read()) //Читаем пока есть данные
                {
                    LeaderBoard.Items.Add($"{read.GetValue(2).ToString()} {read.GetValue(1).ToString()}"); //Добавляем данные в лист итем
                }


                ScoreTestTable.DisconnectDB();
            }
            catch
            {
                ScoreTestTable.DisconnectDB();
            }
        }

    }
}
