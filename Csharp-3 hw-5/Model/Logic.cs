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


    class Logic
    {
        //public static void ThreadEvenNum(object a)
        //{
        //    Thread thread = new Thread(new ParameterizedThreadStart(EvenNum1));
        //    thread.Name = "ThreadEvenNum";
        //    thread.Start(a);
        //}

        public static void EvenNum1(int[] a)
        {
            Stopwatch stopwatch = new Stopwatch();
            int count = 0;

            stopwatch.Start();
            for (int i = 0; i < a.Length; i++) if (a[i] % 2 == 0) count++;
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            Debug.WriteLine("Работа выполнена. Количество чисел - {0}. Время выполнения - {1}", count, timeSpan.ToString());
        }



        public static int EvenNum(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++) if (a[i] % 2 == 0) count++;
            return count;
        }

        public static int MultipleOf3and5(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++) if (a[i] % 3 == 0 && a[i] % 5 == 0) count++;
            return count;
        }

        public static int SimpleNum(int[] a) 
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (SimpleNumCheck(a[i]))
                {
                    count++;
                }
            }         
            return count;
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


        public static int NumPow2(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++) if (PowCheck(a[i])) count++;
            return count;
        }

        public static bool PowCheck(int a)
        {
            if (a == 2) return true;
            else if (a % 2 == 0) return PowCheck(a / 2);
            else return false;
        }

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
