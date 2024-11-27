﻿using System;
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
    /// Логика взаимодействия для Tests.xaml
    /// </summary>
    public partial class Tests : Page
    {

        DB ScoreTestTable = new DB(); //Экземпялр класса с методами для подключения к БДшке
        CurentUser CurrentUser = new CurentUser();

        List<string> qest;
        List<short> TrueAnswer;
        List<short> UserAnswer;
        int index;
        short hod;
        string testName_;

        public Tests(string testName)
        {
            InitializeComponent();
            index = 0;
            testName_ = testName;
            hod = 0;
            UserAnswer = new List<short> { 0,0,0,0,0,0,0,0,0,0 };

            numTest.Text = $"{hod + 1}/10";
            TestName.Text = testName;
            
            if (testName == "База данных")
            {
                qest = new List<string>()
                {
                    "Что такое база данных?",
                    "совокупность данных, организованных по определённым правилам",
                    "совокупность программ для хранения и обработки больших массивов информации",
                    "интерфейс, поддерживающий наполнение и манипулирование данными",

                    "Что такое запись файла реляционной базы данных?",
                    "исключительно однородная информация",
                    "только текстовая информация", 
                    "неоднородная информация",

                    "Какой аналог наиболее точно соответствует реляционной базе данных",
                    "неупорядоченное множество данных",
                    "вектор",
                    "двумерная таблица",

                    "Что из перечисленного не является объектом Access?",
                    "таблицы",
                    "запросы",
                    "ключи",

                    "Для чего предназначены запросы?",
                    "для автоматического выполнения группы команд",
                    "для хранения данных базы",
                    "для отбора и обработки данных базы",

                    "Для чего предназначены отчёты?",
                    "для вывода обработанных данных базы на принтер",
                    "для хранения данных базы",
                    "для ввода данных базы и их просмотра",

                    "В каком диалоговом окне создаются связи между полями таблиц базы данных?",
                    "таблица данных",
                    "схема данных",
                    "схема связей",

                    "Без каких объектов не может существовать база данных?",
                    "отчёты",
                    "таблицы",
                    "модули",

                    "В чём особенность поля «счётчик»?",
                    "данные хранятся не в поле, а в другом месте, а в поле хранится только указатель на то,\n где расположен текст",
                    "имеет ограниченный размер",
                    "служит для ввода действительных чисел",

                    "Какое расширение имеет файл СУБД Access?",
                    "*.db",
                    "*.exe",
                    "*.mdb"
                };

                TrueAnswer = new List<short>() { 1, 1, 3, 2, 3, 1, 2, 2, 3, 1 };
            }
            else if(testName == "Язык программирования C#")
            {
                qest = new List<string>()
                {
                    "Что является основным типом данных в C#",
                    "int",
                    "double",
                    "string",

                    "Какой оператор используется для сравнения двух значений в C#?",
                    "+",
                    "==",
                    "!=",

                    "Как объявляется переменная типа string в C#?",
                    "string x = “значение”",
                    "string x = new string(“значение”)",
                    "string x = значение",

                    "Что делает метод Main() в программе на C#?",
                    "вызывает другой метод",
                    "возвращает значение",
                    "выполняет код программы",

                    "Какой символ используется для разделения идентификаторов и ключевых слов в C#?",
                    "пробел",
                    "запятая",
                    "точка с запятой",

                    "Как создать массив в C#?",
                    "array = new int(размер)",
                    "array = new string(размер)",
                    "array = new object(размер)",

                    "Что делает оператор += в C#?",
                    "вычитает одно число из другого",
                    "умножает два числа",
                    "добавляет одно число к другому",

                    "Как работает цикл for в C#?",
                    "повторяет блок кода заданное количество раз",
                    "повторяет блок кода до достижения определённого условия",
                    "выполняет блок кода заданное количество раз",

                    "Что делает метод ToString() в C#?",
                    "преобразует число в строку",
                    "преобразует строку в число",
                    "выполняет математическую операцию",

                    "Как создать пользовательский класс в C#?",
                    "class MyClass { }",
                    "struct MyStruct { }",
                    "interface MyInterface { }"
                };

                TrueAnswer = new List<short>() { 3, 2, 1, 3, 3, 1, 3, 2, 1, 1 };
            }
            else if (testName == "Машинное обучение")
            {
                qest = new List<string>()
                {
                    "Что такое машинное обучение?",
                    "Процесс, когда компьютеры учатся самостоятельно, без участия человека",
                    "Технология, которая помогает людям быстрее и эффективнее выполнять задачи",
                    "Метод, используемый для создания искусственного интеллекта",

                    "Какие основные этапы машинного обучения?",
                    "Сбор данных, обучение модели, оценка результатов, корректировка параметров",
                    "Анализ данных, разработка алгоритма, тестирование модели, внедрение решения",
                    "Определение проблемы, выбор алгоритма, подготовка данных, оценка результатов",

                    "Что такое модель машинного обучения?",
                    "Набор правил и алгоритмов, которые используются для анализа данных",
                    "Компьютерная программа, которая может самостоятельно\nобучаться на основе предоставленных данных",
                    "Технология, позволяющая компьютерам понимать человеческий язык",

                    "Какие типы машинного обучения существуют?",
                    "Регрессия, классификация, кластеризация, ассоциация",
                    "Обучение с учителем, обучение без учителя, обучение с подкреплением",
                    "Все вышеперечисленное",

                    "Что такое обучение с учителем?",
                    "Когда компьютеры обучаются на основе предоставленных данных и меток",
                    "Процесс, когда компьютеры учатся самостоятельно, без участия человека",
                    "Метод, используемый для создания искусственного интеллекта",

                    "Что такое обучение без учителя?",
                    "Процесс, когда компьютеры учатся самостоятельно, без участия человека",
                    "Метод, используемый для создания искусственного интеллекта",
                    "Технология, позволяющая компьютерам понимать человеческий язык",

                    "Что такое обучение с подкреплением?",
                    "Процесс, когда компьютеры учатся самостоятельно, без участия человека",
                    "Метод, используемый для создания искусственного интеллекта",
                    "Технология, позволяющая компьютерам понимать человеческий язык",

                    "Как оценивается эффективность модели машинного обучения?",
                    "По точности, полноте и F-мере",
                    "По времени обучения и размеру модели",
                    "По количеству используемых алгоритмов и методов",

                    "Какие инструменты и библиотеки используются для машинного обучения?",
                    "Python, TensorFlow, Keras, Scikit-learn",
                    "MATLAB, Octave, Julia, R",
                    "Все вышеперечисленное",

                    "В каких областях применяется машинное обучение?",
                    "В бизнесе, науке, медицине, транспорте",
                    "В образовании, искусстве, спорте, экологии",
                    "Во всех вышеперечисленных областях"
                };

                TrueAnswer = new List<short>() { 1, 1, 3, 2, 1, 2, 2, 1, 1, 3 };
            }
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (index + 4 < qest.Count)
            {
                if (ans1.IsChecked == true)
                {
                    UserAnswer[hod] = 1;
                    ans1.IsChecked = false;

                    index += 4;
                    hod++;
                    Update();
                }
                else if(ans2.IsChecked == true)
                {
                    UserAnswer[hod] = 2;
                    ans2.IsChecked = false;

                    index += 4;
                    hod++;
                    Update();
                }
                else if(ans3.IsChecked == true)
                {
                    UserAnswer[hod] = 3;
                    ans3.IsChecked = false;

                    index += 4;
                    hod++;
                    Update();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Вы не выбрали не один вариант ответа. Вы хотите продолжить?","", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            UserAnswer[hod] = 0;
                            index += 4;
                            hod++;
                            Update();
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                }
            }
            else if (index + 4 >= qest.Count)
            {
                if (ans1.IsChecked == true)
                {
                    UserAnswer[hod] = 1;
                    ans1.IsChecked = false;
                }
                else if (ans2.IsChecked == true)
                {
                    UserAnswer[hod] = 2;
                    ans2.IsChecked = false;
                }
                else if (ans3.IsChecked == true)
                {
                    UserAnswer[hod] = 3;
                    ans3.IsChecked = false;
                }
                else
                {

                    UserAnswer[hod] = 0;
                }

                string Score = Ocenka().ToString();
                
                DBWrite(Convert.ToInt32(Score), testName_);
                NavigationService.Navigate(new LaderBoard(Score));
            }
        }

        private void Update()
        {
            numTest.Text = $"{hod + 1}/10";
            if (index+8 > qest.Count)
            {
                nextQestion.Content = "Завершить тест";
                qestion.Text = qest[index + 0];
                ans1.Content = qest[index + 1];
                ans2.Content = qest[index + 2];
                ans3.Content = qest[index + 3];
            }
            else
            {
                qestion.Text = qest[index + 0];
                ans1.Content = qest[index + 1];
                ans2.Content = qest[index + 2];
                ans3.Content = qest[index + 3];
            }
        }

        private short Ocenka()
        {
            short ocenka = 0;

            for(short i = 0; i < UserAnswer.Count; ++i)
            {
                if (UserAnswer[i] == TrueAnswer[i]) ++ocenka;
                
            }

            return ocenka;
        }
        private void DBWrite(int mark, string testName)
        {
            
            try
            {
                ScoreTestTable.ConnectToDB();
                SqlCommand command = new SqlCommand("AddToScoreBoard", ScoreTestTable.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", CurentUser.name));
                command.Parameters.Add(new SqlParameter("@Score", mark));
                command.Parameters.Add(new SqlParameter("@Testname", testName));

                command.ExecuteNonQuery();

                ScoreTestTable.DisconnectDB();
            }
            catch 
            {
                ScoreTestTable.DisconnectDB();
            }
        }
    }
}
