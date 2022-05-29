using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5
{
    internal class Program
    {
        /**
         * Пользователь последовательно вводит с клавиатуры числа в консоль. 
         * Как только пользователь ввел «пустую строку» вывести на экран сумму введенных чисел и завершить работу программы.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите последовательно числа");

            var numbers = new List<int>();

            //открываем бесконечный цикл
            while(true)
            {
                try
                {
                    string input = Console.ReadLine();

                    //прерываем если есть пустая строка
                    if (input.Equals(String.Empty))
                    {
                        break;
                    }

                    //добавляем в список число
                    numbers.Add(int.Parse(input));
                }
                catch (Exception)
                {
                    Console.WriteLine("Это не число");
                }
            }

            Console.WriteLine("Сумма введенных элементов {0}", numbers.Sum());
        }
    }
}
