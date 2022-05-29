using System;

namespace Task1
{
    internal class Program
    {
        /**
         * Вводится целое число, обозначающее код символа по таблице ASCII. Определить, это код английской буквы или какой-либо иной символ.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число ASCII символа");
            int number = int.Parse(Console.ReadLine());

            if((number >= 65 && number <= 90) || (number >= 97 && number < 122))
            {
                Console.WriteLine("Это буква английского алфавита {0}", Convert.ToChar(number));
            }
            else 
            {
                Console.WriteLine("Это символ - {0}", Convert.ToChar(number));
            }
        }
    }
}
