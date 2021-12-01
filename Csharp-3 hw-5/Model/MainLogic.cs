using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace Csharp_3_hw_5.Model
{

    //    Написать программу, которая в прилагаемом файле будет находить:
    //все четные числа
    //все числа кратные 3 и 5
    //все простые числа
    //все числа являющиеся степенями 2
    class EvenNum
    {
        public int Count { get; private set; }
        public string CalcTime { get; private set; }

        public void Calc(object a)
        {
            int count = 0;
            int[] b = (int[])((int[])a);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.CalcTime = "Вычисление...";

            for (int i = 0; i < b.Length; i++) if (b[i] % 2 == 0) count++;
            this.Count = count;
            
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            this.CalcTime = ts.ToString();
            Debug.WriteLine("Time: " + CalcTime);

        }

        public void _Calc (object a)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Calc));
        }
    }

    class MultipleOf3and5
    {
        public int Count { get; private set; } = 0;
        public string CalcTime { get; private set; }

        public void Calc(object a)
        {
            int count = 0;
            int[] b = (int[])((int[])a);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.CalcTime = "Вычисление...";

            for (int i = 0; i < b.Length; i++) if (b[i] % 3 == 0 && b[i] % 5 == 0) count++;
            this.Count = count;
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            this.CalcTime = ts.ToString();
            Debug.WriteLine("Time: " + CalcTime);
        }
        public void _Calc(object a)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Calc));
            thread.Start(a);
        }
    }

    class SimpleNum
    {
        public int Count { get; private set; } = 0;
        public string CalcTime { get; private set; }

        public void Calc(object a)
        {
            int count = 0;
            int[] b = (int[])((int[])a);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.CalcTime = "Вычисление...";

            for (int i = 0; i < b.Length; i++)
            {
                if (SimpleNumCheck(b[i]))
                {
                    count++;
                }
            }
            this.Count = count;
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            this.CalcTime = ts.ToString();
            Debug.WriteLine("Time: " + CalcTime);
        }

        public static bool SimpleNumCheck(int n)
        {
            bool result = true;
            if (n > 1)
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else result = false;
            return result;
        }
        
        public void _Calc(object a)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Calc));
            thread.Start(a);

        }
    }

    class NumPow2
    {
        public int Count { get; private set; } = 0;
        public string CalcTime { get; private set; }

        public void Calc(object a)
        {
            int count = 0;
            int[] b = (int[])((int[])a);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.CalcTime = "Вычисление...";

            for (int i = 0; i < b.Length; i++) if (PowCheck(b[i])) count++;
            this.Count = count;
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            this.CalcTime = ts.ToString();
            Debug.WriteLine("Time: " + CalcTime);
        }

        public static bool PowCheck(int a)
        {
            if (a == 2) return true;
            else if (a % 2 == 0) return PowCheck(a / 2);
            else return false;
        }
        public void _Calc(object a)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Calc));
            thread.Start(a);

        }
    }

    class MainLogic
    {
        
        public static int[] ReadFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            int count = File.ReadAllLines(fileName).Length;
            int[] numbers = new int[count];
            for (int i = 0; i < count; i++) numbers[i] = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            return numbers;
        }

        
    }
}
