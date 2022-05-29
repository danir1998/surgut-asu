using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new TrainContext();

            #region fill data...
            db.Database.EnsureCreated();
            db.Trains.RemoveRange(db.Trains);
            db.Trains.Add(new Train() { To = "Рига", Category = "скорый", Time = "15:45", Station = "Рижский" });
            db.Trains.Add(new Train() { To = "Ростов", Category = "фирменный", Time = "17:36", Station = "Казанский" });
            db.Trains.Add(new Train() { To = "Самара", Category = "фирменный", Time = "14:20", Station = "Казанский" });
            db.Trains.Add(new Train() { To = "Самара", Category = "скорый", Time = "17:40", Station = "Казанский" });
            db.Trains.Add(new Train() { To = "Самара", Category = "скорый", Time = "15:56", Station = "Казанский" });
            db.Trains.Add(new Train() { To = "Самара", Category = "скорый", Time = "15:56", Station = "Павелецкий" });
            db.Trains.Add(new Train() { To = "Самара", Category = "фирменный", Time = "23:14", Station = "Курский" });
            db.Trains.Add(new Train() { To = "Санкт-Петербург", Category = "скорый", Time = "8:00", Station = "Ленинградский" });
            db.Trains.Add(new Train() { To = "Санкт-Петербург", Category = "скорый", Time = "4:00", Station = "Ленинградский" });
            db.Trains.Add(new Train() { To = "Саратов", Category = "скорый", Time = "14:57", Station = "Павелецкий" });
            db.Trains.Add(new Train() { To = "Саратов", Category = "пассажирский", Time = "15:58", Station = "Павелецкий" });
            db.Trains.Add(new Train() { To = "Саратов", Category = "скорый", Time = "15:30", Station = "Павелецкий" });
            db.SaveChanges();
            #endregion

            Console.WriteLine($"Database path: {db.DbPath}.");

            //SELECT count(*) FROM `Train` WHERE Сategory = 'скорый' OR Station = 'Павелецкий'; - 9
            int task1 = db.Trains.Count(x => x.Category == "скорый" || x.Station == "Павелецкий");
            //SELECT count(*) FROM `Train` WHERE Сategory = 'скорый' OR Time = '40:00'; - 8
            int task2 = db.Trains.Count(x => x.Category == "скорый" || x.Time == "40:00");
            //SELECT count(*) FROM `Train` WHERE Station = 'Павелецкий' OR Time = '35:00'; - 4
            int task3 = db.Trains.Count(x => x.Station == "Павелецкий" || x.Time == "35:00");

            Console.WriteLine("(Категория поезда = «скорый») ИЛИ (Вокзал = «Павелецкий») Ответ: {0}", task1);
            Console.WriteLine("(Категория поезда = «скорый») И (Время в пути 40:00) Ответ: {0}", task2);
            Console.WriteLine("(Вокзал = «Павелецкий») ИЛИ (Время в пути 35:00) Ответ: {0}", task3);
        }
    }


}
