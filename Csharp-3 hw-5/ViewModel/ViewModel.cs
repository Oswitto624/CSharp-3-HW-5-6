using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;

namespace Csharp_3_hw_5.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ICommand StartCalc
        {
            get
            {
                return new DelegateCommand(_StartCalc);
            }
        }

        bool _chkEvenNum = false;
        public bool chkEvenNum
        {
            get
            {
                return _chkEvenNum;
            }
            set
            {
                if (_chkEvenNum != value)
                {
                    _chkEvenNum = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("cbEvenNum"));
                    Debug.WriteLine("EvenNum CheckBox is changed");
                }
            }
        }

        bool _chkMultipleOf3and5 = false;
        public bool chkMultipleOf3and5
        {
            get
            {
                return _chkMultipleOf3and5;
            }
            set
            {
                if (_chkMultipleOf3and5 != value)
                {
                    _chkMultipleOf3and5 = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("cbMultipleOf3and5"));
                    Debug.WriteLine("MultipleOf3and5 CheckBox is changed");
                }
            }
        }

        bool _chkSimpleNum = false;
        public bool chkSimpleNum
        {
            get
            {
                return _chkSimpleNum;
            }
            set
            {
                if (_chkSimpleNum != value)
                {
                    _chkSimpleNum = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("cbSimpleNum"));
                    Debug.WriteLine("SimpleNum CheckBox is changed");
                }
            }
        }

        bool _chkNumPow2 = false;
        public bool chkNumPow2
        {
            get
            {
                return _chkNumPow2;
            }
            set
            {
                if (_chkNumPow2 != value)
                {
                    _chkNumPow2 = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("cbNumPow2"));
                    Debug.WriteLine("NumPow2 CheckBox is changed");
                }
            }
        }

        string filenameText = "Укажите файл!";
        public string FilenameText
        {
            get
            {
                return filenameText;
            }
            set
            {
                if (filenameText != value)
                {
                    filenameText = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("fib"));
                    Debug.WriteLine("New filename: " + filenameText);
                }
            }
        }

        private void _StartCalc(object obj)
        {
            int[] a = Model.Logic.ReadFile(FilenameText);

            if (_chkEvenNum)
            {
                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();
                int b = Model.Logic.EvenNum(a);
                stopwatch1.Stop();
                TimeSpan ts1 = stopwatch1.Elapsed; 
                Debug.WriteLine("Work to EvenNum: " + b);
                Debug.WriteLine("Elapsed Time: " + ts1.ToString());

            }

            if (_chkMultipleOf3and5)
            {
                Stopwatch stopwatch2 = new Stopwatch();
                stopwatch2.Start();
                int c = Model.Logic.MultipleOf3and5(a);
                stopwatch2.Stop();
                TimeSpan ts2 = stopwatch2.Elapsed;
                Debug.WriteLine("Work to Multiple3and5: " + c);
                Debug.WriteLine("Elapsed Time: " + ts2.ToString());

            }

            if (_chkSimpleNum)
            {
                Stopwatch stopwatch3 = new Stopwatch();
                stopwatch3.Start();
                int d = Model.Logic.SimpleNum(a);
                stopwatch3.Stop();
                TimeSpan ts3 = stopwatch3.Elapsed;
                Debug.WriteLine("Work to SimpleNum: " + d);
                Debug.WriteLine("Elapsed Time: " + ts3.ToString());

            }

            if (_chkNumPow2)
            {
                Stopwatch stopwatch4 = new Stopwatch();
                stopwatch4.Start();
                int e = Model.Logic.NumPow2(a);
                stopwatch4.Stop();
                TimeSpan ts4 = stopwatch4.Elapsed; 
                Debug.WriteLine("Work to NumPow2: " + e);
                Debug.WriteLine("Elapsed Time: " + ts4.ToString());

            }

            Debug.WriteLine("All works has been ended.");
        }

        

    }
}
