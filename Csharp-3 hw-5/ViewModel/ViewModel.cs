using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;

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

        Model.EvenNum evenNum = new Model.EvenNum();
        int evenCount = 0;
        string evenCountTime = "none";
        public int EvenCount
        {
            get
            {
                return evenNum.Count;
            }
            set
            {
                if (evenCount != evenNum.Count)
                {
                    evenCount = evenNum.Count;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("evenCount"));
                    Debug.WriteLine("Work for EvenNum. Количество чисел: " + evenCount);
                }
            }
        }
        public string EvenCountTime
        {
            get
            {
                return evenCountTime;
            }
            set
            {
                if (evenCountTime != evenNum.CalcTime)
                {
                    evenCountTime = evenNum.CalcTime;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("evenCountTime"));
                    Debug.WriteLine("Work for EvenNum. Время выполнения: " + evenCountTime);
                }
                
            }
        }

        Model.MultipleOf3and5 multipleNum = new Model.MultipleOf3and5();
        int multipleCount = 0;
        string multipleCountTime = "none";
        public int MultipleCount
        {
            get
            {
                return multipleCount;
            }
            set
            {
                if (multipleCount != multipleNum.Count)
                {
                    multipleCount = multipleNum.Count;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("multipleCount"));
                    Debug.WriteLine("Work for multipleCount. Количество чисел: " + multipleCount);
                }
            }
        }
        public string MultipleCountTime
        {
            get
            {
                return multipleCountTime;
            }
            set
            {
                if (multipleCountTime != simpleNum.CalcTime)
                {
                    multipleCountTime = multipleNum.CalcTime;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("multipleCountTime"));
                    Debug.WriteLine("Work for multipleCountTime. Время выполнения: " + multipleCountTime);
                }
            }
        }

        Model.SimpleNum simpleNum = new Model.SimpleNum();
        int simpleCount = 0;
        string simpleCountTime = "none";
        public int SimpleCount
        {
            get
            {
                return simpleCount;
            }
            set
            {
                if (simpleCount != simpleNum.Count)
                {
                    simpleCount = simpleNum.Count;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SimpleCount"));
                    Debug.WriteLine("Work for SimpleCount. Количество чисел: " + simpleCount);
                }
            }
        }
        public string SimpleCountTime
        {
            get
            {
                return simpleCountTime;
            }
            set
            {
                if (simpleCountTime != simpleNum.CalcTime)
                {
                    simpleCountTime = simpleNum.CalcTime;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("simpleCountTime"));
                    Debug.WriteLine("Work for simpleCountTime. Время выполнения: " + simpleCountTime);
                }
            }
        }
        
        Model.NumPow2 numPow = new Model.NumPow2();
        int numPowCount = 0;
        string numPowCountTime = "none";
        public int NumPowCount
        {
            get
            {
                return numPowCount;
            }
            set
            {
                if (numPowCount != numPow.Count)
                {
                    numPowCount = numPow.Count;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("numPowCount"));
                    Debug.WriteLine("Work for numPowCount. Количество чисел: " + numPowCount);
                }
            }
        }
        public string NumPowCountTime
        {
            get
            {
                return numPowCountTime;
            }
            set
            {
                if (numPowCountTime != numPow.CalcTime)
                {
                    numPowCountTime = numPow.CalcTime;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("numPowCountTime"));
                    Debug.WriteLine("Work for numPowCountTime. Время выполнения: " + numPowCountTime);
                }
            }
        }

        private void _StartCalc(object obj)
        {
            int[] a = Model.MainLogic.ReadFile(FilenameText);

            if (_chkEvenNum)
            {
                evenNum._Calc(a);
                EvenCount = evenNum.Count;
                EvenCountTime = evenNum.CalcTime;
                Debug.WriteLine("Work to EvenNum complete.");
            }

            if (_chkMultipleOf3and5)
            {
                multipleNum._Calc(a);
                MultipleCount = multipleNum.Count;
                MultipleCountTime = multipleNum.CalcTime;
                Debug.WriteLine("Work to Multiple3and5 complete.");
            }

            if (_chkSimpleNum)
            {
                simpleNum._Calc(a);
                SimpleCount = simpleNum.Count;
                SimpleCountTime = simpleNum.CalcTime;
                Debug.WriteLine("Work to SimpleNum complete.");
            }

            if (_chkNumPow2)
            {
                numPow._Calc(a);
                NumPowCount = numPow.Count;
                NumPowCountTime = numPow.CalcTime;
                Debug.WriteLine("Work to NumPow2 complete.");
            }

            Debug.WriteLine("All works has been ended.");
        }
    }
}
