using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfTests
{
    public class QestViewModel : INotifyPropertyChanged
    {
        private Qest qest;

        public QestViewModel(Qest q)
        {
            qest = q;
        }

        public string Name
        {
            get { return qest.Name; }
            set
            {
                qest.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Answer1
        {
            get { return qest.Answer1; }
            set
            {
                qest.Answer1 = value;
                OnPropertyChanged("Answer1");
            }
        }

        public string Answer2
        {
            get { return qest.Answer2; }
            set
            {
                qest.Answer2 = value;
                OnPropertyChanged("Answer2");
            }
        }

        public string Answer3
        {
            get { return qest.Answer3; }
            set
            {
                qest.Answer3 = value;
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
