using System;
using System.Threading;

namespace HW_5_1__console_channeling_program_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Написать приложение, считающее в раздельных потоках:
            // - факториал числа N, которое вводится с клавиатуры;
            // - сумму целых чисел до N.


            Console.WriteLine("Введите целое число... \nВнимание!!! Программа не сосчитает факториал числа, большего, чем 65 из-за ограничения типа переменной ulong!!!");

            ulong a = ulong.Parse(Console.ReadLine());
            Thread thread1 = new Thread(new ParameterizedThreadStart(FactNumThread));
            Thread thread2 = new Thread(new ParameterizedThreadStart(FactNumThread2));
            Thread thread3 = new Thread(new ParameterizedThreadStart(SumIntToNumThread));

            thread1.Name = "thread ToFactNum";
            thread2.Name = "thread ToFactNum2";
            thread3.Name = "thread ToSumIntToNum";
            
            Console.WriteLine("Введено число: " + a);

            thread1.Start(a);
            thread2.Start(a);
            thread3.Start(a);

            //Console.WriteLine("Факториал введённого числа: " + FactNum(a));
            //Console.WriteLine("Факториал2 введённого числа: " + FactNum(a));
            //Console.WriteLine("Сумма целых чисел до введённого числа: " + SumIntToNum(a));

            Console.ReadLine();
        }

        static ulong FactNum(ulong a)
        {
            if (a == 1) return 1;
            return a * FactNum(a - 1);
        }

        static ulong FactNum2(ulong a)
        {
            ulong factorial = 1;
            for (ulong i = 1; i >= a; i++)
            {
                factorial = factorial * i;
            }           
            return a * FactNum(a - 1);
        }

        static ulong SumIntToNum(ulong a)
        {
            ulong num = 0;
            for (ulong i = 0; i <= a; i++) num = num + i;
            return num;
        }

        static void FactNumThread(object b)
        {
            Console.WriteLine("Поток 1 завершил работу. Факториал введённого числа: " + FactNum((ulong)b));
        }

        static void FactNumThread2(object b)
        {
            Console.WriteLine("Поток 2 завершил работу. Факториал введённого числа: " + FactNum2((ulong)b));
        }

        static void SumIntToNumThread(object b)
        {
            Console.WriteLine("Поток 3 завершил работу. Сумма целых чисел до введённого числа: " + SumIntToNum((ulong)b));
        }

    }
}
