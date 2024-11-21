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
    /// Логика взаимодействия для Tests.xaml
    /// </summary>
    public partial class Tests : Page
    {
        List<string> qest;
        List<short> TrueAnswer;
        List<short> UserAnswer;
        int index;
        short hod;

        public Tests(string testName)
        {
            InitializeComponent();
            index = 0;
            hod = 0;
            UserAnswer = new List<short> { 0,0,0,0,0,0,0,0,0,0 };

            TestName.Text = testName;
            
            if (testName == "test1")
            {
                qest = new List<string>()
                {
                    "test1", "ans11", "ans12", "ans13",
                    "test1neme2", "ans21", "ans22", "ans23",
                    "neme3", "ans31", "ans32", "ans33",
                    "neme4", "ans41", "ans42", "ans43",
                    "neme5", "ans51", "ans52", "ans53",
                    "neme6", "ans61", "ans62", "ans63",
                    "neme7", "ans71", "ans72", "ans73",
                    "neme8", "ans81", "ans82", "ans83",
                    "neme9", "ans91", "ans92", "ans93",
                    "neme10", "ans101", "ans102", "ans103"
                };

                TrueAnswer = new List<short>() { 1, 3, 2, 3, 3, 1, 1, 2, 2, 3 };
            }
            else if(testName == "test2")
            {
                qest = new List<string>()
                {
                    "test2", "ans11", "ans12", "ans13",
                    "test2neme2", "ans21", "ans22", "ans23",
                    "neme3", "ans31", "ans32", "ans33",
                    "neme4", "ans41", "ans42", "ans43",
                    "neme5", "ans51", "ans52", "ans53",
                    "neme6", "ans61", "ans62", "ans63",
                    "neme7", "ans71", "ans72", "ans73",
                    "neme8", "ans81", "ans82", "ans83",
                    "neme9", "ans91", "ans92", "ans93",
                    "neme10", "ans101", "ans102", "ans103"
                };

                TrueAnswer = new List<short>() { 1, 3, 2, 3, 3, 1, 1, 2, 2, 3 };
            }
            else if (testName == "test3")
            {
                qest = new List<string>()
                {
                    "test3", "ans11", "ans12", "ans13",
                    "neme2", "ans21", "ans22", "ans23",
                    "neme3", "ans31", "ans32", "ans33",
                    "neme4", "ans41", "ans42", "ans43",
                    "neme5", "ans51", "ans52", "ans53",
                    "neme6", "ans61", "ans62", "ans63",
                    "neme7", "ans71", "ans72", "ans73",
                    "neme8", "ans81", "ans82", "ans83",
                    "neme9", "ans91", "ans92", "ans93",
                    "neme10", "ans101", "ans102", "ans103"
                };

                TrueAnswer = new List<short>() { 1, 3, 2, 3, 3, 1, 1, 2, 2, 3 };
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
                }
                else if(ans2.IsChecked == true)
                {
                    UserAnswer[hod] = 2;
                    ans2.IsChecked = false;
                }
                else if(ans3.IsChecked == true)
                {
                    UserAnswer[hod] = 3;
                    ans3.IsChecked = false;
                }
                else
                {
                    
                    UserAnswer[hod] = 0;
                }

                index += 4;
                hod++;
                Update();
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
                NavigationService.Navigate(new LaderBoard(Ocenka().ToString()));
            }
        }

        private void Update()
        {
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
    }
}
