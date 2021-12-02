using System;
using System.Threading;
using System.Diagnostics;


namespace Csharp_3_hw_5.Model
{
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
}
