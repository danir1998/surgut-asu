using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    internal class Program
    {
        /**
         * Создать массив из 20 элементов в диапазоне (случайным образом)  значений от -15 до 14 включительно. 
         * Определить количество элементов по модулю больших, чем максимальный.
         */
        static void Main()
        {
            Random random = new Random();
            int[] numbers = Enumerable.Range(1, 20).Select(x => random.Next(-15, 15)).ToArray(); //генерим 20 случ. элементов

            int min = numbers.Min();
            int max = numbers.Max();

            int count = numbers.Count(x => max < Math.Abs(x));

            Console.WriteLine("Выводим массив:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Минимальное число: {0}\nМаксимальное число: {1}\nКоличество количество элементов по модулю больших, чем максимальный: {2}", numbers.Min(), numbers.Max(), count);
        }

      
    }
}
