using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Collections.Specialized.BitVector32;
using static SystemOfTests.Qest;

namespace SystemOfTests
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Qest selectedQest;

        public ObservableCollection<Qest> Qests { get; set; }

        public Qest SelectedQest 
        {
            get { return selectedQest; }
            set
            {
                SelectedQest = value;
                OnPropertyChanged("SelectedQest");
            }
        }
        
        public ViewModel (string text)
        {
            if (text == "test1")
            {
                Qests = new ObservableCollection<Qest>
                {
                    new Qest { Name = "asdasd", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdas2", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd3", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd4", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd5", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd6", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd7", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd4", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd5", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd6", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" }
                };
            }
            else if (text == "test2")
            {
                Qests = new ObservableCollection<Qest>
                {
                    new Qest { Name = "asdasd", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdas2", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd3", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd4", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd5", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd6", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd7", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd4", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd5", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd6", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" }
                };
            }
            else if (text == "test3")
            {
                Qests = new ObservableCollection<Qest>
                {
                    new Qest { Name = "asdasd", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdas2", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd3", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd4", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd5", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd6", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd7", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd4", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd5", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" },
                    new Qest { Name = "asdasd6", Answer1 = "adas", Answer2 = "asdadas", Answer3 = "asdasd" }
                };
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
