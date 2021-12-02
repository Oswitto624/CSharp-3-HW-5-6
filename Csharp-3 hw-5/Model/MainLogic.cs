using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Csharp_3_hw_5.Model
{
    //    Написать программу, которая в прилагаемом файле будет находить:
    //все четные числа
    //все числа кратные 3 и 5
    //все простые числа
    //все числа являющиеся степенями 2

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
