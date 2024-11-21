using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfTests
{
    public class Qest : INotifyPropertyChanged
    {  
        private string name;

        private string answer1;
        private string answer2;
        private string answer3;

        public string Name
        {
            get { return name; }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Answer1
        {
            get { return answer1; }

            set
            {
                answer1 = value;
                OnPropertyChanged("Answer1");
            }
        }

        public string Answer2
        {
            get { return answer2; }

            set
            {
                answer2 = value;
                OnPropertyChanged("Answer2");
            }
        }

        public string Answer3
        {
            get { return answer3; }

            set
            {
                answer3 = value;
                OnPropertyChanged("Answer3");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
    }
}
