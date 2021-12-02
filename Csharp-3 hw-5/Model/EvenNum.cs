using System;
using System.Threading;
using System.Diagnostics;


namespace Csharp_3_hw_5.Model
{
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

            Debug.WriteLine("EvenNum nums: " + Count);
            Debug.WriteLine("EvenNum Time: " + CalcTime);

        }

        //private static object lockObject = new object();
        //public void Calc(object a)  //with lockObject
        //{
        //    int count = 0;
        //    int[] b = (int[])((int[])a);
        //    lockObject = b;

        //    lock (lockObject)
        //    {
        //        Stopwatch sw = new Stopwatch();
        //        sw.Start();
        //        this.CalcTime = "Вычисление...";

        //        for (int i = 0; i < b.Length; i++) if (b[i] % 2 == 0) count++;
        //        this.Count = count;

        //        sw.Stop();
        //        TimeSpan ts = sw.Elapsed;
        //        this.CalcTime = ts.ToString();
        //        Debug.WriteLine("Time: " + CalcTime);
        //    }      
        //}

        public void _Calc(object a)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Calc));
            thread.Start(a);
        }
    }
}
