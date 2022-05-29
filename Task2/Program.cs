using System;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        /**
         * С клавиатуры вводится натуральное число. Найти его наибольшую цифру.
         */
        static void Main(string[] args) 
        {
            Console.WriteLine("Введите число");
            string input = Console.ReadLine();
            try
            {
                int[] numbers = input.Select(x => int.Parse(x.ToString())).ToArray(); //приводим все к массиву чисел
                Console.WriteLine("Наибольшее натуральное число {0}", numbers.Where(x => x > 0).Max()); //находим максимальное через LINQ
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка ввода данных, {0}", e);
            }
        }
    }
}
