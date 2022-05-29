using System;

namespace Task4
{
    internal class Program
    {
        /**
         * 	Написать функцию, которая определяет количество разрядов введенного целого числа.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число");
            try
            {
                int input = Math.Abs(int.Parse(Console.ReadLine())); //берем число по модулю, переводим в число
                Console.WriteLine("Количество разрядов введенного числа: {0}", countRank(input));
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка ввода данных {0}", e);
            }
        }
        
        static int countRank(int number)
        {
            int count = 0;

            /**
             * делим введенное число на 10 пока не будет 0... и считаем количество делений
             */
            while (number > 0)
            {
                number = number / 10;
                count++;
            }

            return count;
        }
    }
}
