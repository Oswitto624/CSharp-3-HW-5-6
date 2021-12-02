using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

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
                if (multipleCountTime != multipleNum.CalcTime)
                {
                    multipleCountTime = multipleNum.CalcTime;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("multipleCountTime"));
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
                }
            }
        }

        private async void _StartCalc(object obj)
        {
            Task[] tasks = new Task[4];
            tasks[0] = Task.Run(EvenNumCalcMethod);
            tasks[1] = Task.Run(MultipleNumCalcMethod);
            tasks[2] = Task.Run(SimpleNumCalcMethod);
            tasks[3] = Task.Run(PowNumCalcMethod);

            await Task.WhenAll(tasks);

            //await EvenNumCalcMethod(a);
            //await MultipleNumCalcMethod(a);
            //await SimpleNumCalcMethod(a);
            //await PowNumCalcMethod(a);
            Debug.WriteLine("All works has been ended.");

        }

        private void EvenNumCalcMethod()
        {
            if (_chkEvenNum)
            {
                int[] a = Model.MainLogic.ReadFile(FilenameText);

                evenNum.Calc(a);
                EvenCount = evenNum.Count;
                EvenCountTime = evenNum.CalcTime;
                //Debug.WriteLine("Work to EvenNum complete.");
            }
        }

        private void MultipleNumCalcMethod()
        {
            if (_chkMultipleOf3and5)
            {
                int[] a = Model.MainLogic.ReadFile(FilenameText);

                multipleNum.Calc(a);
                MultipleCount = multipleNum.Count;
                MultipleCountTime = multipleNum.CalcTime;
                //Debug.WriteLine("Work to Multiple3and5 complete.");
            }
        }

        private void SimpleNumCalcMethod()
        {
            if (_chkSimpleNum)
            {
                int[] a = Model.MainLogic.ReadFile(FilenameText);

                simpleNum.Calc(a);
                SimpleCount = simpleNum.Count;
                SimpleCountTime = simpleNum.CalcTime;
                //Debug.WriteLine("Work to SimpleNum complete.");
            }
        }

        private void PowNumCalcMethod()
        {
            if (_chkNumPow2)
            {
                int[] a = Model.MainLogic.ReadFile(FilenameText);

                numPow.Calc(a);
                NumPowCount = numPow.Count;
                NumPowCountTime = numPow.CalcTime;
                //Debug.WriteLine("Work to NumPow2 complete.");
            }
        }
    }
}
